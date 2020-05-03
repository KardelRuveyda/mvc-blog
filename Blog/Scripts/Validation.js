function validateForm() {
    var title = document.forms["myForm"]["title"].value;
    var tags = document.forms["myForm"]["tags"].value;
    var body = document.forms["myForm"]["body"].value;

    if (title == "" || title == null || title == undefined) {
        alert("Title must be filled out");
        return false;
    }

    if (tags == "" || tags == null || tags == undefined) {
        alert("Tags must be filled out");
        return false;
    }

    if (body.length > 1000) {
        alert("You have the limit of 1000 Characters ! ");
        return false;
    } else if (body.length < 500) {
        alert("You must enter at least 500 characters");
        return false;
    }

}
