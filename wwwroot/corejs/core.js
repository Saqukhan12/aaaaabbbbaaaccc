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
        // $.ajax({
        //    type: 'GET',
        //    url: "/CustomerContacts/Index",
        //    success: function (data) {
        //        if (data != null) {
        //            $("#kt_tab_2").html(`<span>Contacts</span>`);
        //            $("#contact").empty();
        //            $("#contact").html(data);

        //        }
        //        $("#kt_modal_generic_2").modal();
        //        //$("#kt_modal_generic_header").html(`<h4>New Customer Contact</h4>`);
        //        //$("#kt_modal_add_customer").addClass("show");
        //    }
        //}); 
}
function AddCustomerContact(Id) {
    $.ajax({
        type: 'GET',
        url: "/CustomerContacts/Create?" + Id,
        success: function (data) {
            if (data != null) {
                $("#kt_modal_generic_scroll").html(data);
            }
            $("#kt_modal_generic").modal();
            $("#kt_modal_generic_header").html(`<h4>New Customer Contact</h4>`);
            //$("#kt_modal_add_customer").addClass("show");
        }
    });
}
function SubmitbtnCustomerContacts() {
    //CustomerContacts/Index
        // $.ajax({
        //    type: 'GET',
        //    url: "/CustomerContacts/Index",
        //    success: function (data) {
        //        if (data != null) {
        //            $("#kt_tab_2").html(`<span>Contacts</span>`);
        //            $("#contact").empty();
        //            $("#contact").html(data);

        //        }
        //        $("#kt_modal_generic_2").modal();
        //        //$("#kt_modal_generic_header").html(`<h4>New Customer Contact</h4>`);
        //        //$("#kt_modal_add_customer").addClass("show");
        //    }
        //}); 
}
function DeleteCustomer(Id) {
    debugger;
    $.ajax({
        type: 'GET',
        url: "/Customers/Delete?Id=" + Id + "&type=_partial",
        success: function (data) {
            if (data != null) {
                $("#kt_modal_generic_scroll_2").empty();

                $("#kt_modal_generic_scroll_2").html(data);
            }
            $("#kt_modal_generic_2").modal();
            $("#kt_modal_generic_header_2").html(`<h4>Delete Customer </h4>`);
            //$("#kt_modal_add_customer").addClass("show");
        }
    });
}
function EditCustomer(Id) {
    debugger;
    $.ajax({
        type: 'GET',
        url: "/Customers/Edit?Id=" + Id + "&type=_partial",
        success: function (data) {
            if (data != null) {
                $("#kt_modal_generic_scroll_2").empty();

                $("#kt_modal_generic_scroll_2").html(data);
            }
            $("#kt_modal_generic_2").modal();
            $("#kt_modal_generic_header_2").html(`<h4>Edit Customer </h4>`);
            //$("#kt_modal_add_customer").addClass("show");
        }
    });
}
function CustomerDetail(Id) {
    $.ajax({
        type: 'GET',
        url: "/Customers/Details?Id=" + Id + "&type=_partial",
        success: function (data) {
            if (data != null) {
                $("#kt_modal_generic_scroll_3").empty();

                $("#kt_modal_generic_scroll_3").html(data);
            }
            $("#kt_modal_generic_3").modal();
            $("#kt_modal_generic_header_3").html(`<h4>Detail Customer </h4>`);
            //$("#kt_modal_add_customer").addClass("show");
        }
    });
}
function AddTenants() {
    $.ajax({
        type: 'GET',
        url: "/Tenants/Create",
        success: function (data) {
            if (data != null) {
                // $("#kt_tab_2").html(`<span>Contacts</span>`);
                $("#kt_modal_generic_scroll").empty();
                $("#kt_modal_generic_scroll").html(data);

            }
            $("#kt_modal_generic").modal();
            //$("#kt_modal_generic_header").html(`<h4>New Customer Contact</h4>`);
            //$("#kt_modal_add_customer").addClass("show");


        }
    });
}


    function CommonDatatables() {
        //Customer DataTables
        //$('#kt_datatable_customers').DataTable();
        ///*('#example_filter').hide();*/ // Hide default search datatables where example is the ID of table
        //$('#customer-search').on('keyup', function () {
        //    $('#kt_datatable_customers')
        //        .DataTable()
        //        .search($('#customer-search').val(), false, true)
        //        .draw();
        //});
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
        $('#role_list_table').DataTable();
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
