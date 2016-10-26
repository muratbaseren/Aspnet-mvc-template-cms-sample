$(function () {
    $.fn.extend({
        loadPageFields: function () {
            cms_mode = false;
            cms_pname = $(this).data("page-name");

            $.ajax({
                method: "GET",
                url: "/PageFieldJS/GetPageFields",
                data: { pname: cms_pname }
            }).done(function (data) {
                cms_mode = data.EditMode;

                $("*[data-field-id]").each(function (i, item) {
                    $(item).attr("contenteditable", cms_mode);

                    for (var i in data.PageFields) {
                        if (data.PageFields[i].Id == $(item).data("field-id")) {
                            $(item).html(data.PageFields[i].Text);
                            break;
                        }
                    }

                    if (cms_mode == true) {
                        // in edit mode..
                        // Prevent anchors default behaivour.
                        if ($(item).attr("href") != null) {
                            $(item).attr("href", "return false;");
                        }

                        // Handle blur event for all page fields..
                        $(item).blur(function () {
                            var field_id = $(this).data("field-id");
                            var field_val = $(this).text();
                            var control = $(this);

                            $.ajax({
                                method: "POST",
                                url: "/PageFieldJS/UpdatePageField",
                                data: { id: field_id, val: field_val, pname: cms_pname }
                            }).done(function (res) {

                                if (res.HasError == false) {
                                    control.css("opacity", 0);

                                    control.animate({
                                        opacity: 1
                                    }, 400);
                                }
                                else {
                                    alert(res.Message);
                                }

                            }).fail(function (err) {
                                alert("Error occured");
                            });
                        });
                    }

                });

            }).fail(function (err) {
                alert("Error occured");
            });
        }
    });

    $("page-identity").loadPageFields();
});