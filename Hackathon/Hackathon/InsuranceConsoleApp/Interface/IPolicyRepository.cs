using InsuranceConsoleApp.Model;    

namespace InsuranceConsoleApp.Interface
{
    public interface IPolicyRepository
    {
        void AddPolicy(Policy policy);
        void UpdatePolicy(int policyId, Policy updatePolicy);
        void DeletePolicy(int policyId);
        Policy SearchPolicy(int policyId);
        List<Policy> GetAllPolicies();
        List<Policy> GetActivePolicies();
        List<Policy> GetInactivePolicies();

    }
}
