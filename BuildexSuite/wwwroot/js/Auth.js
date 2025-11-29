function AddUser() {
    let FullName = $('#FullName').val();
    let Username = $('#Username').val();
    let Email = $('#Email').val();
    let Password = $('#Password').val();

    if (FullName == "" || Username == "" || Email == "" || Password == "") {
        return;
    }

    let UserData = {
        FullName: FullName,
        Username: Username,
        Email: Email,
        Password: Password
    }

    $.ajax({
        url: '/Auth/AddUser',
        method: 'POST',
        data: JSON.stringify(UserData),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (response) {
            const Alert = bootstrap.Toast.getOrCreateInstance($("#Alert"))
            $("#AlertBody").html(response.message);
            Alert.show()

            if (response.success) {
                $('#FullName').val() = "";
                $('#Username').val() = "";
                $('#Email').val() = "";
                $('#Password').val() = "";
            }
        },
        error: function (response) {
            const Alert = bootstrap.Toast.getOrCreateInstance($("#Alert"))
            $("#AlertBody").html(response.responseJSON.message);
            Alert.show()
        }
    });
}

function Login() {
    let Email = $('#LoginEmail').val();
    let Password = $('#LoginPassword').val();

    if (Email == "" || Password == "") {
        return;
    }

    let LoginData = {
        Email: Email,
        Password: Password
    }

    $.ajax({
        url: '/Auth/Login',
        method: 'POST',
        data: JSON.stringify(LoginData),
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (response) {
            if (response.success) {
                window.location.href = '/Home/Index';
            }
            else {
                $('#LoginEmail').parent().addClass("input-warning");
                $('#LoginPassword').parent().addClass("input-warning");
            }
        },
        error: function (response) {
            const Alert = bootstrap.Toast.getOrCreateInstance($("#Alert"))
            $("#AlertBody").html(response.responseJSON.message);
            Alert.show()
        }
    });
}

$(document).ready(function () {
    $("#SignUpBtn").on("click", function () {
        AddUser();
    });

    $("#LoginBtn").on("click", function () {
        $('#LoginEmail').removeClass("input-warning");
        $('#LoginPassword').removeClass("input-warning");
        Login();
    });
});