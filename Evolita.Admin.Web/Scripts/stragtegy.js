function addQuestion() {
    $.post("/Strategies/Question", { strategyid: $(".strategy").data("id"), text: $("#question").val() },
        function (response) {
            if ("error" in response) { alert(response.error); } else { $(".data.questions > ol").append("<li>" + response.text + "</li>"); $("#question").val(""); }
        }).fail(function () {
            alert("Unexpected error occurred. Please check you data and try again.")
        });
}

function addResearch() {
    $.post("/Strategies/Research", { strategyid: $(".strategy").data("id"), text: $("#research").val() },
        function (response) {
            if ("error" in response) { alert(response.error); } else {
                var li = $("<li data-id='" + response.id + "'>" + $("#researchTemplate").html() + "</li>");
                li.find(".name").html(response.text);
                $(".data.research > ol").append(li);
                $("#research").val("");
            }
        }).fail(function () {
            alert("Unexpected error occurred. Please check you data and try again.")
        });
}

function addAction(el) {
    var $row = $(el).closest(".row");
    $.post("/Strategies/Action", {
        strategyid: $(".strategy").data("id"), researchid: $(el).closest(".research-item").data("id"),
        type: $row.find("#actionType").val(), text: $row.find("#actionText").val()
    },
        function (response) {
            if ("error" in response) { alert(response.error); } else {
                $(".research-item[data-id=" + response.researchid + "] .data.actions > ol").append("<li>" + response.type + " - " + response.text + "</li>");
            }
        }).fail(function () {
            alert("Unexpected error occurred. Please check you data and try again.")
        });
    $row.find("#actionType, #actionText").val("");
}
