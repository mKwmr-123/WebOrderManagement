//削除確認用モーダルポップアップ
function deleteCheckDialog(btn, msg) {
    $('#myModalMsg').text(msg);
    $('#myModalOK').attr('onclick', 'selectDeleteDialogOK("' + btn + '");');
    $('#myModalMsgBtn').trigger('click');
    return false;
}

function selectDeleteDialogOK(btn) {
    $('#' + btn).attr('onclick', '');
    $('#' + btn).trigger('click');
    event.preventDefault();
    return false;
}
