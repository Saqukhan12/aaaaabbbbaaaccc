    "use strict";
    // Add Customer Modal Partial View
    function AddCustomer() {
        alert("test");
        $.ajax({
            type: 'GET',
            url: "/Customers/Create?type=_partial",
            success: function (data) {
                if (data != null) {

                    $("#kt_modal_generic_scroll").html(data);
                }
                $("#kt_modal_generic").modal();
                $("#kt_modal_generic_header").html(`<h4>New Customer</h4>`);
                //$("#kt_modal_add_customer").addClass("show");
            }
        });

        //CustomerContacts/Index
         $.ajax({
            type: 'GET',
            url: "/CustomerContacts/Index",
            success: function (data) {
                if (data != null) {
                    $("#kt_tab_2").html(`<span>Contacts</span>`);
                    $("#contact").empty();
                    $("#contact").html(data);

                }
                $("#kt_modal_generic_2").modal();
                //$("#kt_modal_generic_header").html(`<h4>New Customer Contact</h4>`);
                //$("#kt_modal_add_customer").addClass("show");
            }
        }); 
}
function AddCustomerContact() {
    $.ajax({
        type: 'GET',
        url: "/CustomerContacts/Create",
        success: function (data) {
            if (data != null) {

                $("#kt_modal_generic_2_scroll").html(data);
            }
            $("#kt_modal_generic_2").modal();
            $("#kt_modal_generic_header_2").html(`<h4>New Customer Contact</h4>`);
            //$("#kt_modal_add_customer").addClass("show");
        }
    });
}
    function CommonDatatables() {
        //Customer DataTables
        $('#kt_datatable_customers').DataTable();
        /*('#example_filter').hide();*/ // Hide default search datatables where example is the ID of table
        $('#customer-search').on('keyup', function () {
            $('#kt_datatable_customers')
                .DataTable()
                .search($('#customer-search').val(), false, true)
                .draw();
        });
        //CustomersContact DataTables
        $('#kt_datatable_customers_contact').DataTable();
        /*('#example_filter').hide();*/ // Hide default search datatables where example is the ID of table
        //$('#customer-search').on('keyup', function () {
        //    $('#kt_datatable_customers')
        //        .DataTable()
        //        .search($('#customer-search').val(), false, true)
        //        .draw();
        //});
        //AccountDataTable
        $('#kt_datatable_add_user').DataTable();
        /*('#example_filter').hide();*/ // Hide default search datatables where example is the ID of table
        $('#user-search').on('keyup', function () {
            $('#kt_datatable_add_user')
                .DataTable()
                .search($('#user-search').val(), false, true)
                .draw();
        });
    }
    //window.AddCustomer = AddCustomer;
    $(document).ready(function () {
        CommonDatatables();
        //AddCustomer();
    })
