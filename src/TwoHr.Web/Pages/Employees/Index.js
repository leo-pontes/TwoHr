$(function () {    
    var l = abp.localization.getResource('TwoHr');
    var createModal = new abp.ModalManager(abp.appPath + 'Employees/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Employees/EditModal');

    var connection = new signalR.HubConnectionBuilder().withUrl("/my-messaging-hub").build();

    connection.on("ReceiveMessage", function (message) {
        abp.notify.info(message);
    });    

    connection.start().then(function () {

    }).catch(function (err) {
        return console.error(err.toString());
    });

    var dataTable = $('#EmployeesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(twoHr.employees.employee.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('TwoHr.Employees.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('TwoHr.Employees.Delete'),
                                    confirmMessage: function (data) {
                                        return l('EmployeeDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        twoHr.employees.employee.delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('BirthDate'),
                    data: "birthDate",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString();
                    }
                },
                {
                    title: l('Salary'),
                    data: "salaryFormated",                  
                },
                {
                    title: l('Active'),
                    data: "active",
                    render: function (data, type, row) {                      
                        if (data === true) {
                            return '<input type="checkbox" class="editor-active" onclick="return false;" checked>';
                        } else {
                            return '<input type="checkbox" onclick="return false;" class="editor-active">';
                        }
                        return data;
                    },
                },
                {
                    title: l('CreationTime'),
                    data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );

    createModal.onResult(function () {
        //dataTable.ajax.reload();
        
        connection.invoke("SendMessage", $('#Employee_Name').val(), l('WellcomeEmployee'))
            .then(function () {
                
            })
            .catch(function (err) {
                return console.error(err.toString());
            });
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewEmployeeButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});