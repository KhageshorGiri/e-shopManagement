
// ========================= Blog Cagegory ==================== //
// Initialize validation on the form
$('#addNewBlogCategoryForm').validate({
    rules: {
        Category: {
            required: true,
            maxlength: 50
        },
        Description: {
            required: true,
            maxlength: 150
        }
    },
    messages: {
        Category: {
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
    if ($('#addNewBlogCategoryForm').valid()) {
        // Serialize the form data
        const formData = {
            Category: $('#addNewBlogCategoryForm input[name="Category"]').val(),
            Description: $('#addNewBlogCategoryForm textarea[name="Description"]').val()
        };

        // Make the AJAX call
        $.ajax({
            url: '/Admin/BlogCategorySubCategory/AddBlogCategory',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function (response) {
                // Handle success response
                $('#AddNewBlogCategoryModal').modal('hide');
                alert('Blog category added successfully!');
                location.reload();
            },
            error: function (xhr, status, error) {
                console.error('Error:', error);
                alert('Failed to add blog category. Please try again.');
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
$('#addNewBlogSubCategoryForm').validate({
    rules: {
        SubCategory: {
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
        Category: {
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
    if ($('#addNewBlogSubCategoryForm').valid()) {
        // Serialize the form data
        const formData = {
            SubCategory: $('#addNewBlogSubCategoryForm input[id="SubCategory"]').val(),
            CategoryID: $('#addNewBlogSubCategoryForm input[id="CategoryID"]').val(),
            Description: $('#addNewBlogSubCategoryForm textarea[id="SubCategoryDescription"]').val()
        };

        // Make the AJAX call
        $.ajax({
            url: '/Admin/BlogCategorySubCategory/AddBlogSubCategory',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function (response) {
                // Handle success response
                //$('#AddNewBlogCategoryModal').modal('hide'); 
                alert('Blog sub category added successfully!');
                location.reload();
            },
            error: function (xhr, status, error) {
                console.error('Error:', error);
                alert('Failed to add blog sub category. Please try again.');
            }
        });
    } else {
    }
});