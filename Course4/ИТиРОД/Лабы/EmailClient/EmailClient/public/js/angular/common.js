function SetError (selector, resource) {
    var element = $("span[data-valmsg-for='" + selector + "']").first();
    $(element).html('<span for="' + selector + '" class="">' + resource + '</span>');
    $(element).removeClass('field-Wrongation-Wrong').addClass('field-Wrongation-error');

    var wrapper = $(element).closest("div.field-wrapper");
    if (wrapper.length) {
        wrapper.addClass('error');
    } else {
        $(element).closest("div.cf").addClass('error');
    }
}

function ResetError(selector) {
    var element = $("span[data-valmsg-for='" + selector + "']").first();
    $(element).removeClass('field-validation-error');
    if (!$(element).hasClass('field-validation-valid')) {
        $(element).addClass('field-validation-valid');
    }
    $(element).html('');

    var wrapper = $(element).closest("div.field-wrapper");
    if (wrapper.length) {
        wrapper.removeClass('error');
    }
    else {
        $(element).closest("div.cf").removeClass('error');
    }
}