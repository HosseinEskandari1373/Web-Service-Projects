function FillSampleData() {
    $('#cmbx_lng_speaking_r10').val('4');
    $('#cmbx_lng_writing_r10').val('3');
    $('#cmbx_lng_reading_r10').val('2');
    $('#txt_edu_institute_r10').val('دانشگاه آزاد اسلامی واحد نجف آباد');
    $('#cmbx_edu_instituteTypeId_r10').val('2');
    $('#txtRecommenderFirstName').val('بیل');
    $('#txtRecommenderLastName').val('گیتس');
    $('#txtRecommenderRelationship').val('رفیق');
    $('#txtRecommenderJob').val('خیّر');
    $('#txtRecommenderPhone').val('0019361973015');
    $('#txtRecommenderAddress').val('خارج - پلاک 1');
    $('#txtSubReligion').val('شیعه');
    $('#txt_edu_field_r10').val('مهندسی کامپیوتر');
    $('#txtSuggestedJob').val('برنامه نویس');
    $('#ExpectedSalary').val('35000000');
    $('#cmbx_connectionLink').val('1');
    $('#txtFirstName').val('مجید');
    $('#txtLastName').val('یاوری');
    $('#txtFatherName').val('فضل الله');
    $('#txtCertificateNo').val('11946');
    $('#txtNationalId').val('1292648015');
    $('#txtBirthDate').val('1366/5/22');
    $('#txtBirthPlace').val('اصفهان');
    $('#txtCertificatePlace').val('اصفهان');
    $('#txtReligion').val('اسلام');
    $('#txtNationality').val('ایرانی');
    $('#cmbxMaritalStatus').val('1');
    $('#cmbxGender').val('1');
    $('#cmbxMilitaryStatus').val('1');
    $('#txtPhoneNo').val('03134316162');
    $('#txtMobileNo').val('09361973015');
    $('#txtEmail').val('Yavari.majid@gmail.com');
    $('#txtPostalCode').val('8196654962');
    $('#txtAddress').val('اصفهان - ملک شهر - ح طمهری');
    $('#cmbx_edu_degree_r10').val('3');
    $('#cmbx_edu_field_r10').val('1');
    $('#txt_edu_subField_r10').val('نرم افزار');
    $('#txt_edu_instituteName_r10').val('دانشگاه آزاد اسلامی');
    $('#txt_edu_place_r10').val('نجف آباد');
    $('#txt_edu_endYear_r10').val('1388');
    $('#txt_edu_gpa_r10').val('16.18');
    $('#txt_wrk_companyName_r10').val('شرکت فن آوران اطلاعات هم سو');
    $('#txt_wrk_post_r10').val('کارشناس پشتیبانی نرم افزار');
    $('#txt_wrk_duties_r10').val(`پشتیبانی نر م افزار
پشتیبانی سخت افزار
برنامه نویس تیم کنترل هوشمند
        `);
    $('#txt_wrk_startDate_r10').val('1390/6/7');
    $('#txt_wrk_endDate_r10').val('1397/3/31');
    $('#txt_wrk_leaveReason_r10').val('عدم فعالیت شرکت');
    $('#txt_wrk_lastSalary_r10').val('35000000 ریال');
    $('#txt_wrk_phoneNo_r10').val('03136651661');
    $('#cmbx_lng_name_r10').val('1');
    $('#txt_lng_reading_r10').val('70');
    $('#txt_lng_writing_r10').val('60');
    $('#txt_lng_speaking_r10').val('50');
    $('#txtSkill').val(`برنامه نویسی
تحقیق و توسعه
کانفیگ دوربین
کانفیگ کنترلر
`);
    $('#txtRecommender').val('-');
    $('#txtComputerInfo').val(`ICDL
Windows Server`);
    $('#chbx_job_Id_1').prop('checked', true);
    $('#chbx_job_Id_17').prop('checked', true);

}
function RemoveGridRow(e) {

    if ($(e).parent().is('div')) {
        if (($(e).closest("div[id^='tr_wrk_r']").siblings().length) == 0) {
            alert('ورود اطلاعات حداقل یک رکورد لازم می باشد');
            return;
        }
        $(e).closest("div[id^='tr_wrk_r']").remove();
    }
    else {
        if (($(e).closest('tr').siblings().length) == 0) {
            alert('ورود اطلاعات حداقل یک رکورد لازم می باشد');
            return;
        }
        $(e).closest('tr').remove();
    }

}
function CheckValidation() {
    $('.invalidComponent').prop('title', '');
    $('.invalidComponent').removeClass('invalidComponent');
    /////////////////////////////////   Check DropDownLists   /////////////////////////////////
    $('.cmb-req:visible').each(function () {
        var str = $(this).val();
        if (str.length === 0) {
            var ph = $(this).attr('placeholder');
            str = 'لطفاً ' + ph + ' را انتخاب کنید!';
            $(this).addClass('invalidComponent');
            $(this).prop('title', str);
        }
    });
    /////////////////////////////////   Check Required Field   /////////////////////////////////
    $('.txt-req').each(function () {
        var str = $(this).val();
        if (str.length === 0) {
            var ph = $(this).attr('placeholder');
            str = 'لطفاً ' + ph + ' را وارد کنید!';
            $(this).addClass('invalidComponent');
            $(this).prop('title', str);
        }
    });
    /////////////////////////////////   Check Email Field   /////////////////////////////////
    $('.type-email').each(function () {
        var emailAddress = $(this).val();
        var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
        if (regex.test(emailAddress) === false) {
            var ph = $(this).attr('placeholder');
            var str = 'لطفاً ' + ph + '  را با فرمت صحیح وارد کنید!';
            $(this).addClass('invalidComponent');
            $(this).prop('title', str);
        }
    });
    /////////////////////////////////   Check PersianDate Field   /////////////////////////////////
    $('.PersianDatePicker').each(function () {
        var persianDate = $(this).val();
        if (!IsValidDate(persianDate, 1300, new Date().getFullYear() - 622+1 )) {
            var ph = $(this).attr('placeholder');
            str = ph + ' معتبر نمی باشد!';
            $(this).addClass('invalidComponent');
            $(this).prop('title', str);
        }
    });
    persianDate = $('#txtBirthDate').val();
    if (!IsValidDate(persianDate, 1300, new Date().getFullYear() - 622 - 17)) {
        var ph = $('#txtBirthDate').attr('placeholder');
        str = ph + ' معتبر نمی باشد!';
        $('#txtBirthDate').addClass('invalidComponent');
        $('#txtBirthDate').prop('title', str);

    }

    /////////////////////////////////   Check Min Range   /////////////////////////////////
    $('[data-minValue]').each(function () {
        var minVal = $(this).attr('data-minValue');
        var currentValue = $(this).val();
        if (Number(currentValue) < Number(minVal)) {
            var ph = $(this).attr('placeholder');
            str = ph + ' باید بزرگتر یا مساوی ' + minVal + ' باشد!';
            $(this).addClass('invalidComponent');
            $(this).prop('title', str);
        }
    });
    /////////////////////////////////   Check Max Range   /////////////////////////////////
    $('[data-maxValue]').each(function () {
        var minVal = $(this).attr('data-maxValue');
        var currentValue = $(this).val();
        if (Number(currentValue) > Number(minVal)) {
            var ph = $(this).attr('placeholder');
            str = ph + ' باید کوچکتر یا مساوی ' + minVal + ' باشد!';
            $(this).addClass('invalidComponent');
            $(this).prop('title', str);
        }
    });
    /////////////////////////////////   Check NationalId   /////////////////////////////////
    $nId = $("#txtNationalId");
    var nationalId = $nId.val();
    var check = parseInt(nationalId[9]);
    var sum = 0;
    var i;
    for (i = 0; i < 9; ++i) {
        sum += parseInt(nationalId[i]) * (10 - i);
    }
    var mod = sum % 11;
    var invalid = true;

    if ((mod < 2 && check == mod) || (mod >= 2 && check + mod == 11)) {
        invalid = false;
    }
    if ((!/^\d{10}$/.test(nationalId)) || invalid) {
        $nId.addClass('invalidComponent');
        $nId.prop('title', 'کد ملی وارد شده معتبر نمی باشد!');
    }
    /////////////////////////////////   Check Gender And MilitaryStatus   /////////////////////////////////
    var gender
    try {
        gender = $('#cmbxGender').find(":selected").attr('data-extra').toLowerCase();
    }
    catch (exp) { }

    if (gender == 'male') {
        var militaryStatus = $('#cmbxMilitaryStatus').find(":selected");
        if (militaryStatus == '') {
            str = 'لطفا وضعیت خدمت را انتخاب کنید!!';
            $('#cmbxMilitaryStatus').addClass('invalidComponent');
            $('#cmbxMilitaryStatus').prop('title', str);
        }
    }
    $('.invalidComponent:disabled').removeClass('invalidComponent');

    if ($('.invalidComponent').length > 0) {
        var errorInput = $('.invalidComponent').first();
        $('html,body').animate({ scrollTop: errorInput.offset().top-55 }, 500, function () {
            errorInput.focus();
        });
        return false;
    }
    return true;
}
function LastRowIndex(objectName) {
    var index = 0;
    var searchKey = 'tr_' + objectName + '_r';
    $("tr[id^='" + searchKey + "']").each(function () {
        var indexStr = $(this).attr('Id').replace(searchKey, "");
        var indexInt = parseInt(indexStr);
        if (indexInt > index) {
            index = indexInt;
        }
    });
    return index;
}
function AddEducationRow() {
    var count = $('.edu-tr').length;
    if (count >= 5) {
        return;
    }
    var index = LastRowIndex('edu');
    var newIndex = index + 1;
    var key = '_r' + index;
    var replaceWith = '_r' + newIndex;
    var newHtml = $("tr[id^='tr_edu_r" + index + "']")[0].outerHTML.replaceAll(key, replaceWith);
    var newHtml = newHtml.replaceAll('disabled', '');
    $("#edu_body").append(newHtml);
    $('.edu-degree').change(function () {
        var enName = $(this).find(":selected").attr('data-extra').toLowerCase();
        var selectedTR_Id = $(this).parents('tr').first().prop('id');
        var selectedCmbx_Id = $(this).prop('id');
        if (enName == 'diploma') {
            $('#edu_body').children('tr[id!="' + selectedTR_Id + '"]').remove();
            $('#' + selectedTR_Id + '').find('input,select,button').not('#' + selectedCmbx_Id + '').prop('disabled', true);
            $('#btnAddEducation').prop('disabled', true);
        }
        else {
            $('#' + selectedTR_Id + '').find('input,select,button').not('#' + selectedCmbx_Id + '').prop('disabled', false);
            $('#btnAddEducation').prop('disabled', false);
        }
    });
    $('.edu-isFinished').change(function () {
        var controlId = $(this).prop('id');
        var txtYearId = controlId.replaceAll('chbx_edu_IsFinished', '#txt_edu_endYear');
        var txtGPAId = controlId.replaceAll('chbx_edu_IsFinished', '#txt_edu_gpa');
        $(txtYearId).prop('disabled', !this.checked);
        $(txtGPAId).prop('disabled', !this.checked);
    });
}
function AddWorkRow() {
    var count = $('.wrk-tr').length;
    if (count >= 5) {
        return;
    }
    var index = 0;
    $("div[id^='tr_wrk_r']").each(function () {
        var indexStr = $(this).attr('Id').replace('tr_wrk_r', '');
        var indexInt = parseInt(indexStr);
        if (indexInt > index) {
            index = indexInt;
        }
    });
    var newIndex = index + 1;
    var key = '_r' + index;
    var replaceWith = '_r' + newIndex;
    var newHtml = $("div[id^='tr_wrk_r" + index + "']")[0].outerHTML.replaceAll(key, replaceWith);
    $("#divWork").append(newHtml);
    $('.PersianDatePicker').each(function () {
        $(this).persianDatepicker();
    }
    );
    $('.txt-money').autoNumeric('init', { lZero: 'deny', aSep: ',', mDec: 0 });
}
function AddLanguageRow() {
    var count = $('.lng-tr').length;
    if (count >= 5) {
        return;
    }
    var index = LastRowIndex('lng');
    var newIndex = index + 1;
    var key = '_r' + index;
    var replaceWith = '_r' + newIndex;
    var newHtml = $("tr[id^='tr_lng_r" + index + "']")[0].outerHTML.replaceAll(key, replaceWith);
    $("#lng_body").append(newHtml);
}
function CaptchaReferesh() {
    $('#imgCaptcha').attr("src", ShowCaptchaImageURL + '/' + new Date().getTime());
    CaptchaExpireDate = Date.now() + CaptchaTime_Second * 1000;
    $('#txtCaptchCode').val("")
}
function ShowErrorList(lst) {
    $('.errorComponent').prop('title', '');
    $('.errorComponent').removeClass('errorComponent');
    $(lst).each(function (index, obj) {
        $('#' + obj.ControlId).prop('title', '' + obj.ErrorText + '');
        $('#' + obj.ControlId).addClass('errorComponent');
    });
    if ($('.errorComponent').length > 0) {
        var errorInput = $('.errorComponent').first();
        $('html,body').animate({ scrollTop: errorInput.offset().top }, 500, function () {
            errorInput.focus();
        });

    }
}
$(document).ready(function () {
    $('.panel-heading').click(function () {
        $(this).siblings('.panel-body').toggle();
    });
    $('#cmbxGender').change(function () {
        var enName = $('#cmbxGender').find(":selected").attr('data-extra').toLowerCase();

        if (enName == 'female') {
            $('.MilitaryStatus').hide();
            $('#cmbxMilitaryStatus').find('option').first().prop('selected', true);
        }
        else {
            $('.MilitaryStatus').show();
        }

    });
    $('#txtUploadCVFile').on('change', SingleCVFileSelected);
    $('#txtUploadImageFile').on('change', SingleImageFileSelected);
    $('.PersianDatePicker').each(function () {
        $(this).persianDatepicker();
    });
    $('select').prepend("<option value='' selected='selected'></option>");
    $('.edu-degree').change(function () {
        var enName = $(this).find(":selected").attr('data-extra').toLowerCase();
        var selectedTR_Id = $(this).parents('tr').first().prop('id');
        var selectedCmbx_Id = $(this).prop('id');
        if (enName == 'diploma') {
            $('#edu_body').children('tr[id!="' + selectedTR_Id + '"]').remove();
            $('#' + selectedTR_Id + '').find('input,select,button').not('#' + selectedCmbx_Id + '').prop('disabled', true);
            $('#btnAddEducation').prop('disabled', true);
        }
        else {
            $('#' + selectedTR_Id + '').find('input,select,button').not('#' + selectedCmbx_Id + '').prop('disabled', false);
            $('#btnAddEducation').prop('disabled', false);
        }
    });
    $('.job-Checkbox').change(function () {
        if ($('.job-Checkbox:checked').length == 0) {
            $('#divSuggestedJob').show();
            $('#txtSuggestedJob').addClass('txt-req');
            $('#divSuggestedJob').prop('disabled', false);
        }
        else {
            $('#divSuggestedJob').hide();
            $('#txtSuggestedJob').removeClass('txt-req');
            $('#divSuggestedJob').prop('disabled', true);
        }
    });
    $('#cmbxBirthProvince').change(function () {
        var selectedProvinceId = $('#cmbxBirthProvince').find("option:selected").val();
        GetBirthCities(selectedProvinceId);
    });
    $('#cmbxProvince').change(function () {
        var selectedProvinceId = $('#cmbxProvince').find("option:selected").val();
        GetCities(selectedProvinceId);
    });
    $('.edu-isFinished').change(function () {
        var controlId = $(this).prop('id');
        var txtYearId = controlId.replaceAll('chbx_edu_IsFinished', '#txt_edu_endYear');
        var txtGPAId = controlId.replaceAll('chbx_edu_IsFinished', '#txt_edu_gpa');
        $(txtYearId).prop('disabled', !this.checked);
        $(txtGPAId).prop('disabled', !this.checked);
    });
    $('#chbxNoJobHistory').change(function () {
       
        var isChecked = $(this).prop('checked');
        $('.workRow *').prop('disabled', isChecked);
        $('#btnAddWorkRow').prop('disabled', isChecked);
        
    });
});
setInterval(function () {
    var remainTime = Math.ceil((CaptchaExpireDate-Date.now())/ 1000);
    if (remainTime > 0) {
        $('#lblCaptchaExpire').text(remainTime + " ثانیه تا انقضا")
    }
    else {
        CaptchaReferesh();
    }
}, 1000);
function SingleCVFileSelected() {
    var selectedFile = ($("#txtUploadCVFile"))[0].files[0];
    if (selectedFile) {
        if (selectedFile.size > 1024 * 1024 * MaxCVSize_MB) {
            alert('حد اکثر حجم مجاز برای ارسال فایل ' + MaxCVSize_MB+' مگابایت می باشد.');
            $('#txtUploadCVFile').val('');
            return;
        }
        var allowedFileTypes = ["application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/pdf", "application/msword"];


        if (allowedFileTypes.indexOf(selectedFile.type) == -1) {
            alert('لطفا رزومه را در قالب Pfd و یا Word آپلود کنید.');
            $('#txtUploadCVFile').val('');
            return;
        }
    }
}
function SingleImageFileSelected() {
    var selectedFile = ($("#txtUploadImageFile"))[0].files[0];
    if (selectedFile) {
        if (selectedFile.size > 1024 * 1024 * MaxImageSize_MB) {
            alert('حد اکثر حجم مجاز برای ارسال تصویر ' + MaxImageSize_MB + ' مگابایت می باشد.');
            $('#txtUploadImageFile').val('');
            return;
        }
        var allowedFileTypes = ["image/jpg", "image/jpeg", "image/png"];

        if (allowedFileTypes.indexOf(selectedFile.type) == -1) {
            alert('لطفا تصویر را در قالب JPG و یا PNG آپلود کنید.');
            $('#txtUploadImageFile').val('');
            return;
        }
            var reader = new FileReader();
            reader.onload = function (e) {
                $('#blah')
                    .attr('src', e.target.result)
                    .width(60)
                    .height(80);
            };
        reader.readAsDataURL(selectedFile);
    }
}
function IsValidDate(date,minYear,maxYear) {
    var arr = date.split('/');
    if (arr.length != 3)
        return false;
    var year = arr[0];
    var month = arr[1];
    var day = arr[2];

    if (!($.isNumeric(year) && $.isNumeric(month) && $.isNumeric(day)))
        return false;
    if (year < minYear || (year >maxYear) || month < 1 || day < 1)
        return false;

    if (day > 31)
        return false;
    if (month > 12)
        return false;
    return true;
}
function GetBirthCities(provinceId) {
    $.ajax({
        url: GetCitiesURL + '/' + provinceId,
        type: 'GET',
        success: function (response) {
            var $jsonCiteis = $("#cmbxBirthCity");
            $jsonCiteis.empty();
            $jsonCiteis.prepend("<option value='' selected='selected'></option>");
            $.each(response, function (index, value) {
                $jsonCiteis.append("<option value='" + value.Name + "'>" + value.Name + "</option>");
            });
        },
        error: function () {
        },
        complete: function () {
        },
        cache: false,
        contentType: false,
        processData: false
    });
}
function GetCities(provinceId) {
    $.ajax({
        url: GetCitiesURL + '/' + provinceId,
        type: 'GET',
        success: function (response) {
            var $jsonCiteis = $("#cmbxCity");
            $jsonCiteis.empty();
            $jsonCiteis.prepend("<option value='' selected='selected'></option>");
            $.each(response, function (index, value) {
                $jsonCiteis.append("<option value='" + value.Name + "'>" + value.Name + "</option>");
            });
        },
        error: function () {
        },
        complete: function () {
        },
        cache: false,
        contentType: false,
        processData: false
    });
}
function UploadCVFile() {
    var selectedFile = ($("#txtUploadCVFile"))[0].files[0];
    if (selectedFile) {
        if (selectedFile.size > MaxCVSize_MB*1024 * 1024) {
            $('#txtUploadCVFile').val('');
            return;
        }
		
        $('#btnUploadCV').prop('disabled', true);
        var form = $('#FormUpload')[0];
        var dataString = new FormData(form);
        $.ajax({
            url: CVUploaderURL,
            type: 'POST',
            xhr: function () {  // Custom XMLHttpRequest
                var myXhr = $.ajaxSettings.xhr();
                if (myXhr.upload) { // Check if upload property exists
                    //myXhr.upload.onprogress = progressHandlingFunction
                }
                return myXhr;
            },
            success: function (response) {
                var successPost = response.success;
                if (successPost == true) {
                    alert('رزومه با موفقیت آپلود شد.');
                    $('#btnUploadCV').hide();
                    $('#txtUploadCVFile').hide();
                    $('#lblSuccessCVUpload').removeClass('d-none');

                }
                else {
                    var message = response.message;
                    if (message.length > 0) {
                        alert(message);
                    }
                }
            },
            error: function (e) {
				alert(e);
                alert('خطا در آپلود فایل!!!');
            },
            complete: function () {
                $('#btnUploadCV').prop('disabled', false);

            },
            data: dataString,
            cache: false,
            contentType: false,
            processData: false
        });
    }
    else {
        alert('هیچ فایلی جهت آپلود انتخاب نشده است.');
    }
}
function UploadImageFile() {
    var selectedFile = ($("#txtUploadImageFile"))[0].files[0];
    if (selectedFile) {
        if (selectedFile.size > MaxImageSize_MB * 1024 * 1024) {
            $('#txtUploadImageFile').val('');
            return;
        }

        $('#btnUploadImage').prop('disabled', true);
        var form = $('#FormUpload')[0];
        var dataString = new FormData(form);
        $.ajax({
            url: ImageUploaderURL,
            type: 'POST',
            xhr: function () {  // Custom XMLHttpRequest
                var myXhr = $.ajaxSettings.xhr();
                if (myXhr.upload) { // Check if upload property exists
                    //myXhr.upload.onprogress = progressHandlingFunction
                }
                return myXhr;
            },
            success: function (response) {
                var successPost = response.success;
                if (successPost == true) {
                    alert('تصویر با موفقیت آپلود شد.');
                    $('#btnUploadImage').hide();
                    $('#txtUploadImageFile').hide();
                    $('#lblSuccessImageUpload').removeClass('d-none');

                }
                else {
                    var message = response.message;
                    if (message.length > 0) {
                        alert(message);
                    }
                }
            },
            error: function (e) {
                alert(e);
                alert('خطا در آپلود تصویر!!!');
            },
            complete: function () {
                $('#btnUploadImage').prop('disabled', false);

            },
            data: dataString,
            cache: false,
            contentType: false,
            processData: false
        });
    }
    else {
        alert('هیچ فایلی جهت آپلود انتخاب نشده است.');
    }
}
String.prototype.replaceAll = function (token, newToken, ignoreCase) {
    var _token;
    var str = this + "";
    var i = -1;

    if (typeof token === "string") {

        if (ignoreCase) {

            _token = token.toLowerCase();

            while ((
                i = str.toLowerCase().indexOf(
                    _token, i >= 0 ? i + newToken.length : 0
                )) !== -1
            ) {
                str = str.substring(0, i) +
                    newToken +
                    str.substring(i + token.length);
            }

        } else {
            return this.split(token).join(newToken);
        }

    }
    return str;
};
function SendData() {
    $('.errorComponent').prop('title', '');
    $('.errorComponent').removeClass('errorComponent');
    if (CheckValidation() === false) {
        return;
    }
    if ((($("#txtUploadCVFile"))[0].files.length > 0) && ($('#btnUploadCV').css('display') != "none")) {
        if (confirm('فایل انتخابی شما هنوز آپلود نشده، آیا میخواهید بدون آپلود رزومه اطلاعات را ارسال کنید؟')) {
            // Continue;
        } else {
            return;
        }
    }
    var checkedJO = $('input[id^="chbx_job_Id_"]:checked').length;
    var formObject = $('form').serialize();
    $('#btnSubmit').prop('disabled', true);
    $.ajax({
        url: PostBackURL,
        type: 'POST',
        data: formObject,
        success: function (response) {
            var successPost = response.success;
            if (successPost == true) {
                $('.errorComponent').prop('title', '');
                $('.errorComponent').removeClass('errorComponent');
				setTimeout(function () { window.location = "http://index-holding.com"; }, 5000);
				$('#myModal').modal('show');
            }
            else {
                var message = response.message;
                if (message.length > 0) {
                    alert(message);
                }
                ShowErrorList(response.errors);
            }
        }
    })
        //.fail(function () {
        //    alert("error");
		.fail(function (jqXHR, textStatus) {
			alert("error: " + textStatus);
        })
        .always(function () {
            $('#btnSubmit').prop('disabled', false);
        });
}
$(function () {
    var topoffset = 55; //variable for menu height

    //Use smooth scrolling when clicking on navigation
    $('.navbar-nav a').click(function () {
        if (location.pathname.replace(/^\//, '') ===
            this.pathname.replace(/^\//, '') &&
            location.hostname === this.hostname) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                $('html,body').animate({
                    scrollTop: target.offset().top - topoffset
                }, 500);
                return false;
            } //target.length
        } //click function
    }); //smooth scrolling
});
$(function ($) {
    $('.txt-money').autoNumeric('init', { lZero: 'deny', aSep: ',', mDec: 0 });
});  