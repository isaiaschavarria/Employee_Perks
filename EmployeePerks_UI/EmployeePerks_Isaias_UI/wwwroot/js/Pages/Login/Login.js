function Login() {

    this.Validate = function () {
        var div = $('#validations');

        if (div.text() !== "") {
            Swal.fire({
                title: "Message",
                text: div.text(),
                icon: "error"
            });
        }
    }
}

$(document).ready(function () {
    var view = new Login();
    view.Validate();
});