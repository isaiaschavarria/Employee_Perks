function CreateVacation() {

    this.InitView = function () {
        $('#btnCreate').click(function () {
            var view = new CreateVacation();
            view.SubmitVacationRequests();
        });
    }

    //{
    //    "id": 0,
    //    "employeeId": 0,
    //    "startDay": "2025-03-05T02:27:22.407Z",
    //    "endDay": "2025-03-05T02:27:22.407Z",
    //    "justification": "string",
    //    "active": true
    //}
    this.SubmitVacationRequests = function () {
        var api_url = "http://localhost:5269";
        //var api_url = "http://app.azurewebsites.com";


        //armar el objeto que se va enviar al API
        var vacation = {}
        vacation.employeeId = EMPLOYEE_ID;
        vacation.startDay = $('#startDay').val();
        vacation.endDay = $('#endDay').val();
        vacation.justification = $('#txtJustification').val();

        //hacer el llamado al API
        $.ajax({
            headers: {
                'Accept': "application/json",
                'Content-Type': "application/json"
            },
            method: "POST",
            url: api_url + "/api/Vacation/CreateVacation",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(vacation),
            hasContent: true
        }).done(function () {
            Swal.fire({
                title: "Message",
                text: "Vacation Request created sucessfully",
                icon: "info"
            });

        }).fail(function (error) {
            alert('Hubo un error al llamar al API ', error);

        });
    }
}

$(document).ready(function () {
    var view = new CreateVacation();
    view.InitView();
});