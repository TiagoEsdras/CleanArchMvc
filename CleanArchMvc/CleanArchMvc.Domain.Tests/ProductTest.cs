using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductTest
    {
        [Fact(DisplayName = "Try create product with valid state")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10.99m, 100, "Product image");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Try create product with negative id")]
        public void CreateProduct_WithNegativeId_ThrowsDomainExceptionValidationInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 10.99m, 100, "Product image");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Theory(DisplayName = "Try create product when name is null")]
        [InlineData("")]
        [InlineData(null)]
        public void CreateProduct_WithNameNull_ThrowsDomainExceptionValidationNameIsRequired(string invalidName)
        {
            Action action = () => new Product(1, invalidName, "Product Description", 10.99m, 100, "Product image");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required.");
        }

        [Fact(DisplayName = "Try create product when name's length < 3")]
        public void CreateProduct_WithNamesLengthLessThan3_ThrowsDomainExceptionValidationMinimum3Characters()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 10.99m, 100, "Product image");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid name. Minimum 3 characters.");
        }

        [Theory(DisplayName = "Try create product when description is null")]
        [InlineData("")]
        [InlineData(null)]
        public void CreateProduct_WithDescriptionNull_ThrowsDomainExceptionValidationDescriptionIsRequired(string invalidDescription)
        {
            Action action = () => new Product(1, "Product Name", invalidDescription, 10.99m, 100, "Product image");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid description. Description is required.");
        }

        [Fact(DisplayName = "Try create product when name's length < 3")]
        public void CreateProduct_WithDescriptionLengthLessThan3_ThrowsDomainExceptionValidationMinimum5Characters()
        {
            Action action = () => new Product(1, "Product Name", "De", 10.99m, 100, "Product image");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid description. Minimum 5 characters.");
        }

        [Fact(DisplayName = "Try create product when price less than 0")]
        public void CreateProduct_WithPriceLessThan0_ThrowsDomainExceptionValidationInvalidPrice()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -55.99m, 100, "Product image");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid price value.");
        }

        [Fact(DisplayName = "Try create product when stock less than 0")]
        public void CreateProduct_WithStockLessThan0_ThrowsDomainExceptionValidationInvalidStock()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10.99m, -100, "Product image");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid stock value.");
        }

        [Theory(DisplayName = "Try create product when image is null")]
        [InlineData("")]
        [InlineData(null)]
        public void CreateProduct_WithImageNull_NoDomainExceptionValidation(string image)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10.99m, 100, image);
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Try create product when image is null")]
        [InlineData("")]
        [InlineData(null)]
        public void CreateProduct_WithImageNull_NoNullReferenceException(string image)
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 10.99m, 100, image);
            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Try create product when image greater than 250 characters")]
        public void CreateProduct_WithImageGreaterThan250Characters_ThrowsDomainExceptionValidationMaximum250Characters()
        {
            var invalidImageUrl = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.";
            Action action = () => new Product(1, "Product Name", "Product Description", 10.99m, 100, invalidImageUrl);
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid image name. Maximum 250 characters.");
        }
    }
}