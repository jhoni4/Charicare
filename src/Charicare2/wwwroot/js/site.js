
//// Write your Javascript code.
//$( document ).ready(function() {
//    if (Page.User.Identity.IsAuthenticated)//check if logged in user exists
//    { 
//        $("#loginChecker").addClass("private").show();
//    }
//    else
//    {
//        $("#loginChecker").hide();
//    }

//});
//alert(@TempData["Message"]);
//$(document).ready(function () {
//    toastr.success('Added')
//})
if (ViewBag.message != null)
{

        $(document).ready(function () {   
            toastr.success('Added')
        })
}