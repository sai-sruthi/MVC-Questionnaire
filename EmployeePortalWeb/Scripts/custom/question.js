$(document).ready(function () {
	// var
	var parentClosure = {};

	// var init

	// functions

	function deleteQuestion() {
	    var questionId = $(this).closest('[question-id]').attr('question-id');
		$.ajax({
			url: 'Question/Delete',
			data: {
			    questionId: questionId
			},
			success: deleteQuestionSH
		});
	}

	function deleteQuestionSH(data) {
		    parentClosure.divQuestions.find('div[question-id=' + data.id + ']').remove();
	}

	function editQuestion() {
		parentClosure.modalTitle.text("Edit Question");
		var questionId = $(this).closest('div[question-id]').attr('question-id');

		parentClosure.questionModalBody.load("Question/LoadQuestionForm", {
		    questionId: questionId
		}, function () {
			parentClosure.questionModal.modal('show');
			$.validator.unobtrusive.parse('#formQuestion');
		});
	}

	function createQuestion() {
	    var questionId = -1;
		parentClosure.modalTitle.text("Add Question");
		parentClosure.questionModalBody.load("Question/LoadQuestionForm", {
		    questionId: questionId
		}, function () {
		    parentClosure.questionModal.modal('show');
			$.validator.unobtrusive.parse('#formQuestion');
		});
	}

	function saveQuestion() {
		$('#formQuestion').submit();
		window.event.preventDefault();
	}

	function saveQuestionSH(data) {
		if (data.responseJSON) {
			window.location.reload();
		}
		else {
			parentClosure.paperModalBody.html(data.responseText);
			$.validator.unobtrusive.parse('#formQuestion');
		}
	}

	function pageSetup() {
		// variables init
		parentClosure.divQuestions = $('#divQuestions');
		parentClosure.questionModal = $('#questionModal');
		parentClosure.modalTitle = $('#modalTitle');
		parentClosure.btnSave = $('#btnSave');
		parentClosure.btnCreate = $('#btnCreate');
		parentClosure.questionModalBody = $('#questionModalBody');

		// events init
		parentClosure.divQuestions.on('click',
			'a[action=delete]', deleteQuestion);
		parentClosure.divQuestions.on('click',
			'a[action=edit]', editQuestion);
		parentClosure.btnCreate.bind('click', createQuestion);
		parentClosure.btnSave.bind('click', saveQuestion);
	}

	// init
	function init() {
		pageSetup();
		window.saveQuestionSH = saveQuestionSH;
	}

	init();
});