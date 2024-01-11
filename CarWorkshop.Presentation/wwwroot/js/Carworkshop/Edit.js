$(document).ready(function () {
    $("#createCarWorkshopServiceModal form").submit(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {

                $("#createCarWorkshopServiceModal").modal('hide');

                toastr["success"]("Created CarWorkshop Service")
            },
            error: function  () {
                toastr["error"]("Something went wrong")
            }
        })
    })

})