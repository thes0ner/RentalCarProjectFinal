using RentalCar.Core.Entities.Concrete;
using RentalCar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalCar.Business.Constants
{
    public static class Messages
    {
        public static string AddedBrand = "Brand added.";
        public static string DeletedBrand = "Brand deleted.";
        public static string UpdatedBrand = "Brand updated.";
        public static string ListedBrands = "Brands listed.";

        public static string AddedCar = "Car added.";
        public static string DeletedCar = "Car deleted.";
        public static string UpdatedCar = "Car updated.";
        public static string ListedCars = "Cars listed.";

        public static string AddedColor = "Color added.";
        public static string DeletedColor = "Color delted.";
        public static string UpdatedColor = "Color updated.";
        public static string ListedColors = "Colors listed.";

        public static string AddedCustomer = "Customer added.";
        public static string DeletedCustomer = "Customer deleted.";
        public static string UpdatedCustomer = "Customer updated.";
        public static string ListedCustomers = "Customers listed.";

        public static string AddedRental = "Rental added.";
        public static string DeletedRental = "Rental deleted.";
        public static string UpdatedRental = "Rental updated.";
        public static string ListedRentals = "Rentals listed.";

        public static string AddedUser = "User added.";
        public static string DeletedUser = "User deleted.";
        public static string UpdatedUser = "User updated.";
        public static string ListedUsers = "Users listed.";

        public static string ListedCarDetails = "Car Details.";
        public static string ListedBrandDetails = "Brand Details.";
        public static string ListedColorDetails = "Color Details.";
        public static string ListedCustomerDetails = "Customer Details.";
        public static string ListedRentalDetails = "Rental Details.";
        public static string ListedUserDetails = "User Details.";

        public static string CarModelAlreadyExist = "Car model already exist.";
        public static string BrandNameAlreadyExist = "Brand name already exist.";
        public static string ColorNameAlreadyExist = "Color name already exist.";
        public static string RecordDoesNotExist = "Record does not exist.";
        public static string RentalAlreadyExist = "Rental already exist.";
        public static string UserNameAlreadyExist = "User already exist.";
        public static string CustomerNameAlreadyExist = "Customer already exist.";
        public static string EmailAlreadyExist = "Email already exist.";
        public static string PhoneAlreadyExist = "Phone number already exist.";

        public static string CarImageLimitExceeded = $"Image limit exceed, Car must contain maximum 5 images.";
        public static string CarImageAdded = "Added.";
        public static string CarImageDeleted = "Deleted";
        public static string CarImageUpdated = "Modified";

        public static string AuthorizationDenied = "You don't have the permission!";
        public static string UserNotFound = "User not found!";
        public static string PasswordError = "Wrong password!";
        public static string SuccessfulLogin = "Login successful.";
        public static string UserAlreadyExists = "User already exist.";
        public static string UserRegistered = "User successfully registered";
        public static string AccessTokenCreated = "Access token successfully created.";
        public static string AccessTokenFaild = "Failed to create token.";
    }
}
