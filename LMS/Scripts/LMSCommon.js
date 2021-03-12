var Popup, dataTable;

function closeJQryDlg() {
   Popup.dialog('close');
   //Popup.dialog('destroy').remove();
}

function PopupForm(url, dlgTitle) {
   var formDiv = $('<div/>');
   $.get(url)
   .done(function (response) {
      formDiv.html(response);
      formDiv.find('.form-group input').attr('class', '');
      formDiv.find('.form-group input').attr('class', 'form-control');
      Popup = formDiv.dialog({
        autoOpen: true,
        show: 'slide',
        modal: true,
        title: dlgTitle,
        hide: 'slide',
        width: '700px'
      });
   });
}

function SubmitForm(form) {
   debugger;
   $.validator.unobtrusive.parse(form);
   if ($(form).valid()) {
      $.ajax({
         type: "POST",
         url: form.action,
         data: $(form).serialize(),
         success: function (data) {
            if (data.success) {
               debugger;
               $.notify(data.message, {
                  globalPosition: "top right",
                  className: "success"
               })

               dataTable.ajax.reload();
               closeJQryDlg();
            } else {
               debugger;
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
        debugger;
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