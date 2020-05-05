function validateCommentForm() {
    var name = document.forms["myForm"]["name"].value;
    var email = document.forms["myForm"]["email"].value;
    var body = document.forms["myForm"]["body"].value;

    if (name == "" || name == null || name == undefined) {
        alert("Name must be filled out");
        return false;
    }

    if (email == "" || email == null || email == undefined) {
        alert("Email must be filled out");
        return false;
    }

    if (body == "" || body == null || body == undefined) {
        alert("Body must be filled out");
        return false;
    }

    if (body.length > 100) {
        alert("You have the limit of 100 Characters ! ");
        return false;
    } else if (body.length < 10) {
        alert("You must enter at least 10 characters");
        return false;
    }

}
