core = (function () {
    "use strict";

    // Add Customer Modal Partial View
    function AddCustomer() {
        //alert("test");
        $.ajax({
            type: 'GET',
            url: "/Customers/Create",
            success: function (data) {
                if (data != null) {
                    $("#MetronicThemeModel").empty();
                    $("#MetronicThemeModel").html(data);

                }
                $("#kt_modal_add_customer").modal();
                $("#kt_modal_add_customer_header").html(`<h4>Create Customer</h4>`);
                //$("#kt_modal_add_customer").addClass("show");


            }
        });
    }
    $(document).ready(function () {
        //Customer DataTables
        $('#kt_datatable_customers').DataTable();
        /*('#example_filter').hide();*/ // Hide default search datatables where example is the ID of table
        $('#customer-search').on('keyup', function () {
            $('#kt_datatable_customers')
                .DataTable()
                .search($('#customer-search').val(), false, true)
                .draw();
        });

        //AccountDataTable
        $('#kt_datatable_add_user').DataTable();
        /*('#example_filter').hide();*/ // Hide default search datatables where example is the ID of table
        $('#user-search').on('keyup', function () {
            $('#kt_datatable_add_user')
                .DataTable()
                .search($('#user-search').val(), false, true)
                .draw();
        });


    });

    
})