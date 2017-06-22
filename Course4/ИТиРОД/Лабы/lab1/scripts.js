function on_send_native_request(){
	request = new XMLHttpRequest()
	request.open('GET', "NATIVE_REQUEST", false) 
	request.send()
	set_div(request.responseText)	
}	
function on_send_request_by_jquery(){
	 $.ajax({
        type: "GET",
        async: "true",
        url: "JQUERY_REQUEST",
        success: function(data) {
            set_div(data)
        }
    });
}

function set_div(data){
	const divId = 'responseDiv';
	if(document.getElementById(divId) === null)
	{
		var root = document.getElementById('0');
	
		var div = document.createElement('div');
		div.id = divId;
		div.style.margin = "15px";
		
		root.parentNode.insertBefore(div, root);
	}
	
	document.getElementById(divId).innerHTML = data;

}

//получаем элемент json с name = 0; 0 -- корневой элемент
function initialize() {
    addRootElementsAsync('0')
}

function addRootElements(itemId) {
    var jsonItem = get_json_item(itemId)
    var htmlElement = $("[id=" + jsonItem.id + "]");

    if (htmlElement.is("li")) {
        htmlElement = htmlElement.children("ul")
    }

    for (var index in jsonItem.children) {
        var child = get_json_item(jsonItem.children[index])
        append_json_item_to_html_element(htmlElement, child)
    }
}

function addRootElementsAsync(itemId) {
    request = new XMLHttpRequest()
	request.onreadystatechange = function() {
		if (request.readyState == 4 && request.status == 200) {
			var jsonItem = JSON.parse(request.responseText)
			var htmlElement = $("[id=" + jsonItem.id + "]");

			if (htmlElement.is("li")) {
				htmlElement = htmlElement.children("ul")
			}

			for (var index in jsonItem.children) {
				var child = get_json_item(jsonItem.children[index])
				append_json_item_to_html_element(htmlElement, child)
			}
		}
	}
	request.open('GET', String(itemId), true)
	request.send()
}

function get_json_item(id){
	request = new XMLHttpRequest()    
	request.open('GET', String(id), false)
	request.send()
	return JSON.parse(request.responseText)
}

/*element -- ul*/
function append_json_item_to_html_element(element, child){
	/*настраиваем чекбокс*/
    var checked
    var opa = $(element).siblings("input");
	if ($(element).siblings("input").is(":checked"))
		checked = "checked"
	
    /*настраиваем кнопку*/
	var clipped = child.children.length > 0
	var disabled
	var content="+"	
	if (!clipped){
		disabled = "disabled"
		content = "&nbsp;"
	}
	element.append('<li id="'+child.id+'" class="folder">\
						<input type="checkbox" onchange="toggle(this)" '+checked+'>\
							<button class="button" onclick="clip(this)"'+disabled+'>'+content+'</button>\
									'+child.name+'\
						</input>\
						<ul class="folder">\
						</ul>\
				   </li>')	 
}

function clip(element) {
    if (element.innerHTML === "+")
    {
        element.innerHTML = "-";
        /*показываем на странице круг*/
        $(".loading").show();
        setTimeout(function () {
            if ($(element).siblings("ul").children("li").length == 0) {
                addRootElements($(element).parent().attr('id'))
            }
            $(".loading").hide();
            $(element).siblings("ul").show()
        }, 500)
        
    } else
    {
        element.innerHTML = "+";
        $(element).parent().children("ul").empty();
    }   
}

//помечаем чекбоксы
//element -- checkbox
function toggle(checkboxElement, isSubChecked) {

    //чекаем дочерние элементы
    if ($(checkboxElement).siblings("ul").children("li").length > 0 && !isSubChecked) {
		recursive_checking($(checkboxElement).parent());		
        /*var subelements = $(checkboxElement).siblings("ul").children("li")
        subelements.each(function (index) {
			$(subelements[index]).children("input").prop("checked", $(checkboxElement).is(":checked"))
            recursive_checking($(subelements[index]))
        })*/
    }

    //все элементы находящиеся на одном уровне с текущим li
	var elements = $(checkboxElement).parent().parent().children("li")
    var checkedCheckboxCount = $(elements).children("input:checkbox:checked").length;
    
    //если все дочерние чекнуты -- чекаем родительский элемент
    if (checkedCheckboxCount == elements.length && elements.length != 0)
		$(checkboxElement).parent().parent().siblings("input").prop("checked", true)
	else	
	    $(checkboxElement).parent().parent().siblings("input").prop("checked", false)

    var parent = $(checkboxElement).parent().parent();
	if ($(checkboxElement).parent().parent().attr("id") == "0")
		return 
	toggle($(checkboxElement).parent().parent().siblings("input"), true)
}

/*чекаем все дочерние элементы, если чекнут родительский*/
function recursive_checking(liElement) {
    if ($(liElement).children("ul").children("li").length != 0)
    {
        var subelements = $(liElement).children("ul").children("li")
        subelements.each(function (index) {
            $(subelements[index]).children("input").prop("checked", $(liElement).children("input").is(":checked"))
            recursive_checking($(subelements[index]))
        })
    }    
}