function VacationList() {

    this.InitView = () => {

    }

    this.LoadVacationData = function () {
        var api_url = "http://localhost:5269";

        $.ajax({
            url: api_url + "/api/Vacation/GetAllVacation",
            method: "GET",
            contentType: "application/json:charset=utf-8",
            dataType: "json"
            
        }).done(function (result) {
            console.log(result);
            var employeeId = EMPLOYEE_ID;
            if (result.result === "OK") {
                var filtered = result.data.filter(item => item.employeeId === employeeId);

                gridApi.setGridOption('rowData', filtered);
                sessionStorage["VacationData"] = filtered;//Evaluar
                localStorage["VacationLocal"] = filtered; //Evaluar
            } else {
                Swal.fire({
                    title: "Message",
                    text: "Error Loading Vacation Data: " + result.message,
                    icon: "error"
                });
            }
        }).fail(function(error) {
            Swal.fire({
                title: "Message",
                text: "Error Calling the API " + error,
                icon: "error"
            });
        });
    }
}

$(document).ready(function () {
    var view = new VacationList();
    view.InitView();
    view.LoadVacationData();
});

