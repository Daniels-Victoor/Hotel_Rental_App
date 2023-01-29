// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
	$('.minus').click(function () {
		var $input = $(this).parent().find('.inputss');
		var count = parseInt($input.val()) - 1;
		count = count < 1 ? 1 : count;
		$input.val(count);
		$input.change();
		CalculateHotelPrice();
		return false;
	});
	$('.plus').click(function () {
		var $input = $(this).parent().find('.inputss');
		$input.val(parseInt($input.val()) + 1);
		$input.change();
		CalculateHotelPrice();
		
		return false;
	});
		
});

function CalculateHotelPrice()
{
		var numberOfNights = $("#input").val();
	var price = $("#price").text();
	$("#night").text(numberOfNights); 
		$("#priceDisplay").text(numberOfNights * price);
}



(function ($) {
    function compareDates(startDate, endDate, format) {
        var temp, dateStart, dateEnd;
        try {
            dateStart = $.datepicker.parseDate(format, startDate);
            dateEnd = $.datepicker.parseDate(format, endDate);
            if (dateEnd < dateStart) {
                temp = startDate;
                startDate = endDate;
                endDate = temp;
            }
        } catch (ex) { }
        return { start: startDate, end: endDate };
    }

    $.fn.dateRangePicker = function (options) {
        options = $.extend({
            "changeMonth": false,
            "changeYear": false,
            "numberOfMonths": 2,
            "rangeSeparator": " - ",
            "useHiddenAltFields": false
        }, options || {});

        var myDateRangeTarget = $(this);
        var onSelect = options.onSelect || $.noop;
        var onClose = options.onClose || $.noop;
        var beforeShow = options.beforeShow || $.noop;
        var beforeShowDay = options.beforeShowDay;
        var lastDateRange;

        function storePreviousDateRange(dateText, dateFormat) {
            var start, end;
            dateText = dateText.split(options.rangeSeparator);
            if (dateText.length > 0) {
                start = $.datepicker.parseDate(dateFormat, dateText[0]);
                if (dateText.length > 1) {
                    end = $.datepicker.parseDate(dateFormat, dateText[1]);
                }
                lastDateRange = { start: start, end: end };
            } else {
                lastDateRange = null;
            }
        }

        options.beforeShow = function (input, inst) {
            var dateFormat = myDateRangeTarget.datepicker("option", "dateFormat");
            storePreviousDateRange($(input).val(), dateFormat);
            beforeShow.apply(myDateRangeTarget, arguments);
        };

        options.beforeShowDay = function (date) {
            var out = [true, ""], extraOut;
            if (lastDateRange && lastDateRange.start <= date) {
                if (lastDateRange.end && date <= lastDateRange.end) {
                    out[1] = "ui-datepicker-range";
                }
            }

            if (beforeShowDay) {
                extraOut = beforeShowDay.apply(myDateRangeTarget, arguments);
                out[0] = out[0] && extraOut[0];
                out[1] = out[1] + " " + extraOut[1];
                out[2] = extraOut[2];
            }
            return out;
        };

        options.onSelect = function (dateText, inst) {
            var textStart;
            if (!inst.rangeStart) {
                inst.inline = true;
                inst.rangeStart = dateText;
            } else {
                inst.inline = false;
                textStart = inst.rangeStart;
                if (textStart !== dateText) {
                    var dateFormat = myDateRangeTarget.datepicker("option", "dateFormat");
                    var dateRange = compareDates(textStart, dateText, dateFormat);
                    myDateRangeTarget.val(dateRange.start + options.rangeSeparator + dateRange.end);
                    inst.rangeStart = null;
                    if (options.useHiddenAltFields) {
                        var myToField = myDateRangeTarget.attr("data-to-field");
                        var myFromField = myDateRangeTarget.attr("data-from-field");
                        $("#" + myFromField).val(dateRange.start);
                        $("#" + myToField).val(dateRange.end);
                    }
                }
            }
            onSelect.apply(myDateRangeTarget, arguments);
        };

        options.onClose = function (dateText, inst) {
            inst.rangeStart = null;
            inst.inline = false;
            onClose.apply(myDateRangeTarget, arguments);
        };

        return this.each(function () {
            if (myDateRangeTarget.is("input")) {
                myDateRangeTarget.datepicker(options);
            }
            myDateRangeTarget.wrap("<div class=\"dateRangeWrapper\"></div>");
        });
    };
}(jQuery));

$(document).ready(function () {
    $("#txtDateRange").dateRangePicker({
        showOn: "focus",
        rangeSeparator: " to ",
        dateFormat: "yy-mm-dd",
        useHiddenAltFields: true,
        constrainInput: true
    });
});


