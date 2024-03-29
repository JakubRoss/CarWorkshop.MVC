$(document).ready(function () {

    const RenderCarWorkshopServices = (services, container) => {

        container.empty();

        for (const service of services) {

            container.append(

                `<div class="card border-secondary mb-3 m-3" style="max-width: 18rem;">

                    <div class="card-header">${service.price}</div>

                    <div class="card-body">

                    <h5 class="card-title">${service.description}</h5>

                </div>

                </div>`)

        }

    }



    const LoadCarWorkshopServices = () => {

        const container = $("#services");

        const carWorkshopEncodedName = container.data("encodedName");

        $.ajax({

            url: `/CarWorkshop/${carWorkshopEncodedName}/CarWorkshopService`,
            type: 'get',
            success: function (data) {

                if (!data.length) {

                    container.html("There ara no services for this workshop")
                } else {
                    RenderCarWorkshopServices(data, container)
                }
            },
            error: function () {

                toastr["error"]("Something went wrong")
            }
        })

    }



    LoadCarWorkshopServices() //Wywolanie tej funkcji


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