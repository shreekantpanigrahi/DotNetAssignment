using System;

namespace InsuranceConsoleApp.Model
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyHolderName { get; set; }
        public PolicyTypeEnum PolicyType { get; set; }
        public DateTime PolicyStartDate { get; set; }
        public DateTime PolicyEndDate { get; set; }

        public bool IsActive { get; set; }


        public enum PolicyTypeEnum
        {
            Life,
            Health,
            Vehicle,
            Travel
        }

        public Policy(int policyId, string policyHolderName, PolicyTypeEnum policyType, DateTime policyStartDate, DateTime policyEndDate)
        {
            if (string.IsNullOrWhiteSpace(policyHolderName))
            {
                throw new ArgumentException("Policy holder name cannot be null or empty.");
            }
            if (policyStartDate > policyEndDate)
            {
                throw new ArgumentException("Policy start date cannot be greater than policy end date.");
            }

            // Assign values
            PolicyId = policyId; 
            PolicyHolderName = policyHolderName;
            PolicyType = policyType;
            PolicyStartDate = policyStartDate;
            PolicyEndDate = policyEndDate;
            IsActive = true;
        }

        public override string ToString()
        {
            return $"Policy ID: {PolicyId}\n" +
                   $"Holder: {PolicyHolderName}\n" +
                   $"Type: {PolicyType}\n" +
                   $"Start: {PolicyStartDate:yyyy-MM-dd}\n" +
                   $"End: {PolicyEndDate:yyyy-MM-dd}\n" +
                   $"Status: {(IsActive ? "Active" : "Inactive")}";
        }

        //public bool IsActive()
        //{
        //    return PolicyEndDate > DateTime.Now;
        //}

    }
}
