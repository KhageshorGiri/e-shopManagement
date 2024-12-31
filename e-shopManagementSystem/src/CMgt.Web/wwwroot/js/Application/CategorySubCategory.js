
// ========================= Blog Cagegory ==================== //
// Initialize validation on the form
$('#addNewCategoryForm').validate({
    rules: {
        CategoryName: {
            required: true,
            maxlength: 50
        },
        Description: {
            required: true,
            maxlength: 150
        }
    },
    messages: {
        CategoryName: {
            required: "Category is required.",
            maxlength: "Category Name should be less than 50 characters."
        },
        Description: {
            required: "Description is required.",
            maxlength: "Description should be less than 150 characters."
        }
    },
    errorClass: 'text-danger',
    errorElement: 'span',
    highlight: function (element) {
        $(element).addClass('is-invalid');
    },
    unhighlight: function (element) {
        $(element).removeClass('is-invalid');
    }
});

// Handle button click
$('#btnAddNewCategory').on('click', function () {
    if ($('#addNewCategoryForm').valid()) {
        // Serialize the form data
        const formData = {
            CategoryName: $('#addNewCategoryForm input[name="CategoryName"]').val(),
            Description: $('#addNewCategoryForm textarea[name="Description"]').val()
        };

        // Make the AJAX call
        $.ajax({
            url: '/Admin/Category/AddCategory',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function (response) {
                // Handle success response
                $('#AddNewCategoryModal').modal('hide');
                alert('Category added successfully!');
                location.reload();
            },
            error: function (xhr, status, error) {
                console.error('Error:', error);
                alert('Failed to add category. Please try again.');
            }
        });
    } else {
       
    }
});


// ========================= Blog Sub Cagegory ==================== //
$("#CategoryOptions").on('change', function () {
    var categoryId = $("#CategoryOptions option:selected").val();
    $("#CategoryID").val(categoryId);
});

// Initialize validation on the form
$('#addNewSubCategoryForm').validate({
    ignore: "", // This includes hidden fields in validation
    rules: {
        SubCategoryName: {
            required: true,
            maxlength: 50
        },
        CategoryID: {
            required: true,
        },
        SubCategoryDescription: {
            required: true,
            maxlength: 150
        }
    },
    messages: {
        SubCategoryName: {
            required: "Sub Category is required.",
            maxlength: "Sub Category Name should be less than 50 characters."
        },
        CategoryID: {
            required: "Category is required.",
        },
        SubCategoryDescription: {
            required: "Description is required.",
            maxlength: "Description should be less than 150 characters."
        }
    },
    errorClass: 'text-danger',
    errorElement: 'span',
    highlight: function (element) {
        $(element).addClass('is-invalid');
    },
    unhighlight: function (element) {
        $(element).removeClass('is-invalid');
    }
});

// Handle button click
$('#btnAddNewSubCategory').on('click', function () {
    if ($('#addNewSubCategoryForm').valid()) {
        // Serialize the form data
        const formData = {
            SubCategoryName: $('#addNewSubCategoryForm input[id="SubCategoryName"]').val(),
            CategoryID: $('#addNewSubCategoryForm input[id="CategoryID"]').val(),
            Description: $('#addNewSubCategoryForm textarea[id="SubCategoryDescription"]').val()
        };

        console.log(formData);

        // Make the AJAX call
        $.ajax({
            url: '/Admin/Category/AddSubCategory',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function (response) {
                // Handle success response
                //$('#AddNewBlogCategoryModal').modal('hide'); 
                alert('Sub category added successfully!');
                location.reload();
            },
            error: function (xhr, status, error) {
                console.error('Error:', error);
                alert('Failed to add sub category. Please try again.');
            }
        });
    } else {
    }
});

// Delete Category
$(".delete-category").on('click', function () {
    var categoryId = $(this).data('id')

    // Make the AJAX call
    $.ajax({
        url: '/Admin/Category/DeleteCategory',
        type: 'GET',
        contentType: 'application/json',
        data: { id: categoryId },
        success: function (response) {
            // Handle success response
            //$('#AddNewBlogCategoryModal').modal('hide'); 
            alert(response.message);
            location.reload();
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            alert('Failed to delete category. Please try again.');
        }
    });
});


// Delete SubCategory
$(".delete-subcategory").on('click', function () {
    var subCatgoryId = $(this).data('id')

    // Make the AJAX call
    $.ajax({
        url: '/Admin/Category/DeleteSubCategory',
        type: 'GET',
        contentType: 'application/json',
        data: { id: subCatgoryId },
        success: function (response) {
            // Handle success response
            //$('#AddNewBlogCategoryModal').modal('hide'); 
            alert(response.message);
            location.reload();
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            alert('Failed to delete category. Please try again.');
        }
    });
});