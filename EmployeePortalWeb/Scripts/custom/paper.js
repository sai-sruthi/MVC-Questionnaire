$(document).ready(function () {
	// var
	var parentClosure = {};

	// var init

	// functions

	function deletePaper() {
	    var paperId = $(this).closest('[paper-id]').attr('paper-id');
	    //var r = confirm("Do you want to delete the question paper?");
	    //if (r === true) {
	        $.ajax({
	            url: 'Paper/Delete',
	            data: {
	                paperId: paperId
	            },
	            success: deletePaperSH
	        });
	    //}
	}

	function deletePaperSH(data) {
	    if (data.msg === "Deleted") {
	        parentClosure.divPapers.find('div[paper-id=' + data.id + ']').remove();
	    }
	    else {
	        alert("Can not delete a Paper containing Questions");
	    }
		
	}

	//function detailsPaper() {
	//    var paperId = $(this).closest('[paper-id]').attr('paper-id');
	//    $.ajax({
	//        url: 'Paper/Details',
	//        data: {
	//            paperId: paperId
	//        },
	//        success: alert('hi')
	//    });
	//}

	


	function editPaper() {
	    parentClosure.modalTitle.text("Edit Paper");
		var paperId = $(this).closest('div[paper-id]').attr('paper-id');

		parentClosure.paperModalBody.load("Paper/LoadPaperForm", {
		    paperId: paperId
		}, function () {
			parentClosure.paperModal.modal('show');
			$.validator.unobtrusive.parse('#formPaper');
		});
	}

	function createPaper() {
	    var paperId = -1;
	    parentClosure.modalTitle.text("Add Paper");
		parentClosure.paperModalBody.load("Paper/LoadPaperForm", {
		    paperId: paperId
		}, function () {
			parentClosure.paperModal.modal('show');
			$.validator.unobtrusive.parse('#formPaper');
		});
	}

	function savePaper() {
		$('#formPaper').submit();
		window.event.preventDefault();
	}

	function savePaperSH(data) {
		if (data.responseJSON) {
			window.location.reload();
		}
		else {
			parentClosure.paperModalBody.html(data.responseText);
			$.validator.unobtrusive.parse('#formPaper');
		}
	}

	function pageSetup() {
		// variables init
		parentClosure.divPapers= $('#divPapers');
		parentClosure.paperModal = $('#paperModal');
		parentClosure.modalTitle = $('#modalTitle');
		parentClosure.btnSave = $('#btnSave');
		parentClosure.btnCreate = $('#btnCreate');
		parentClosure.paperModalBody = $('#paperModalBody');

		// events init
		parentClosure.divPapers.on('click',
			'a[action=delete]', deletePaper);
		parentClosure.divPapers.on('click',
			'a[action=edit]', editPaper);
		//parentClosure.divPapers.on('click',
		//	'a[action=details]', detailsPaper);
		parentClosure.btnCreate.bind('click', createPaper);
		parentClosure.btnSave.bind('click', savePaper);
	}

	// init
	function init() {
		pageSetup();
		window.savePaperSH = savePaperSH;
	}

	init();
});