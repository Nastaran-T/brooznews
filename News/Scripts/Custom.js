$("#NewGroup").click(function () {

    $.get("/Admin/PageGroups/Create", function (res) {

        $("#myModal").modal();
        $("#myModalLabel").html("افزودن گروه جدید");
        $("#myModalBody").html(res);
    });
});

function Edit(id) {

    $.get("/Admin/PageGroups/Edit/" + id, function (res) {

        $("#myModal").modal();
        $("#myModalLabel").html("ویرایش گروه ");
        $("#myModalBody").html(res);
    });
}

function Delete(id) {

    $.get("/Admin/PageGroups/Delete/" + id, function (res) {

        $("#myModal").modal();
        $("#myModalLabel").html("حذف گروه ");
        $("#myModalBody").html(res);
    });
}

function AddNewComment(id) {
    $.ajax({
        url: "/Comment/" + id,
        method: "Post",
        data: { name: $("#txtName").val(), email: $("#txtEmail").val(), comment: $("#txtComment").val() }
    }).done(function (res) {
        alert("salam");
        $("#CommentList").html(res);

        $("#txtName").val("");
        $("#txtEmail").val("");
        $("#txtComment").val("");

    });
};

    
//بخاطر اینکه برای ارسال آی دی خبر از مدلمون استفاده شده نوشتتن این مدل از ایجکس باید داخل صفحه باشه بنابراین من برای جداسازی جی کویری ها از روش بالا رفتم 

//$("#addNewComment").click(function () {

//    $.ajax({
//        url: "/Comment/" +@Model.PageId,
//    method: "Post",
//        data: { name: $("#txtName").val(), email: $("#txtEmail").val(), comment: $("#txtComment").val() }
//}).done(function (res) {
//    $("#CommentList").html(res);

//    $("#txtName").val("");
//    $("#txtEmail").val("");
//    $("#txtComment").val("");

//});

    






