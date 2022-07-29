using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryTest
    {
        [Fact(DisplayName = "Try create category with valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Try create category with negative id")]
        public void CreateCategory_WithNegativeId_ThrowsDomainExceptionValidationInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Theory(DisplayName = "Try create category when name is null")]
        [InlineData("")]
        [InlineData(null)]
        public void CreateCategory_WithNameNull_ThrowsDomainExceptionValidationNameIsRequired(string invalidName)
        {
            Action action = () => new Category(1, invalidName);
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required.");
        }

        [Fact(DisplayName = "Try create category when name's length < 3")]
        public void CreateCategory_WithNamesLengthLessThan3_ThrowsDomainExceptionValidationMinimum3Characters()
        {
            Action action = () => new Category(1, "Ab");
            action.Should()
                .Throw<DomainExceptionValidation>().WithMessage("Invalid name. Minimum 3 characters.");
        }
    }
}