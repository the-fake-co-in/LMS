var Popup, dataTable;

function closeJQryDlg() {
    if (Popup) {
        Popup.dialog('close');
        //Popup.dialog('destroy').remove();
    } 
}

function PopupForm(url, dlgTitle, width) {
   var formDiv = $('<div/>');
   $.get(url)
   .done(function (response) {
       formDiv.html(response);
       formDiv.find('.form-group input').attr('class', '');
       formDiv.find('.form-group input').attr('class', 'form-control');
       $('select').removeAttr("htmlattributes").addClass("form-control");
       Popup = formDiv.dialog({
           autoOpen: true,
           show: 'slide',
           modal: false,
           title: dlgTitle,
           hide: 'slide',
           responsive: true,
           dialogClass: "test",
           width: width + "px"
       });
   });
}

function SubmitForm(form) {
   $.validator.unobtrusive.parse(form);
   if ($(form).valid()) {
      $.ajax({
         type: "POST",
         url: form.action,
         data: $(form).serialize(),
         success: function (data) {
            if (data.success) {
               $.notify(data.message, {
                  globalPosition: "top right",
                  className: "success"
               })

               dataTable.ajax.reload();
               closeJQryDlg();
            } else {
               $.notify(data.message, {
                  globalPosition: "top right",
                  className: "error"
               })
               closeJQryDlg();
            }
         }
      });
   }
   return false;
}

function Delete(id, dlgTitle, postUrl) {
    if (confirm('Are You Sure to Delete this ' + dlgTitle + ' Record ?')) {
      $.ajax({
         type: "POST",
         data: {
            "Id": id,
            "IsDeleted": true
         },
         url: postUrl,
         success: function (data) {
            if (data.success) {
               dataTable.ajax.reload();
               $.notify(data.message, {
                  globalPosition: "top right",
                  className: "success"
               })
            } else {
               $.notify(data.message, {
                  globalPosition: "top right",
                  className: "error"
               })
            }
         }
      });
   }
}

$(document).mouseup(function (e) {
   var container = $(".ui-dialog");

   // if the target of the click isn't the container nor a descendant of the container
   if (!container.is(e.target) && container.has(e.target).length === 0) {
       closeJQryDlg();
   }
});