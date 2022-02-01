function validation() {
    var Name = document.getElementById('name').value;
    var Email = document.getElementById('email').value;
    var Mobile = document.getElementById('mobile').value;
    var Locaton = document.getElementById('locaton').value;

    if (Name == "") {
        document.getElementById('error_user').innerHTML = " ** Please fill the Name field";
        return false;
    }

    else if ((Name.length <= 2) || (Name.length > 20)) {
        document.getElementById('error_user').innerHTML = " ** Name lenght must be between 2 and 20";
        return false;
    }

    else if (!isNaN(Name)) {
        document.getElementById('error_user').innerHTML = " ** only characters are allowed";
        return false;
    }
    else {
        document.getElementById('error_user').innerHTML = '';
    }

    if (Email == "") {
        document.getElementById('error_Email').innerHTML = " ** Please fill the Email id` field";
        return false;
    }
    else if (Email.indexOf('@') <= 0) {
        document.getElementById('error_Email').innerHTML = " ** '@' Invalid Position";
        return false;
    }
    else if ((Email.charAt(Email.length - 4) != '.') && (Email.charAt(Email.length - 3) != '.')) {
        document.getElementById('error_Email').innerHTML = " ** . Invalid Position";
        return false;
    }
    else {
        document.getElementById('error_Email').innerHTML = '';
    }
    if (Mobile == "") {
        document.getElementById('error_Mobile').innerHTML = " ** Please fill the Mobile field";
        return false;
    }
    else {
        document.getElementById('error_Mobile').innerHTML = '';
    }
    if (Locaton == "") {
        document.getElementById('error_Locaton').innerHTML = " ** Please fill the Locaton field";
        return false;
    }
    else {
        document.getElementById('error_Locaton').innerHTML = '';
    }

}
    //Name error msg
    function ErrorName() {

        var Name = document.getElementById('name').value;

        if (Name == "") {
            document.getElementById('error_user').innerHTML = " ** Please fill the NameName field";
            return false;
        }

        else if ((Name.length <= 2) || (Name.length > 20)) {
            document.getElementById('error_user').innerHTML = " ** NameName lenght must be between 2 and 20";
            return false;
        }

        else if (!isNaN(Name)) {
            document.getElementById('error_user').innerHTML = " ** only characters are allowed";
            return false;
        }
        else {
            document.getElementById('error_user').innerHTML = '';
        }
    }

    function ErrorEmail() {
        var Email = document.getElementById('email').value;

        if (Email == "") {
            document.getElementById('error_Email').innerHTML = " ** Please fill the Email id` field";
            return false;
        }
        else if (Email.indexOf('@') <= 0) {
            document.getElementById('error_Email').innerHTML = " ** '@' Invalid Position";
            return false;
        }
        else if ((Email.charAt(Email.length - 4) != '.') && (Email.charAt(Email.length - 3) != '.')) {
            document.getElementById('error_Email').innerHTML = " ** . Invalid Position";
            return false;
        }
        else {
            document.getElementById('error_Email').innerHTML = '';
        }
    }

    function ErrorMobile() {
        var Mobile = document.getElementById('mobile').value;

        if (Mobile == "") {
            document.getElementById('error_Mobile').innerHTML = " ** Please fill the Mobile field";
            return false;
        }
        else {
            document.getElementById('error_Mobile').innerHTML = '';
        }

    }

    function ErrorLocaton() {
        var Locaton = document.getElementById('locaton').value;

        if (Locaton == "") {
            document.getElementById('error_Locaton').innerHTML = " ** Please fill the Locaton field";
            return false;
        }
        else {
            document.getElementById('error_Locaton').innerHTML = '';
        }
    }
