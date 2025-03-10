using InsuranceConsoleApp.Interface;
using InsuranceConsoleApp.Model;
using InsuranceConsoleApp.Exceptions;

namespace InsuranceConsoleApp.Repository
{
    public class PolicyRepository : IPolicyRepository
    {
        Dictionary<int, Policy> policies = new Dictionary<int, Policy>();
        private int _nextPolicyId = 1;
        public void AddPolicy(Policy policy)
        {
            policy.PolicyId = _nextPolicyId++;
            policies.Add(policy.PolicyId, policy);
        }

        public void UpdatePolicy(int policyId, Policy updatedPolicy)
        {
            if (!policies.ContainsKey(policyId))
                throw new PolicyNotFoundException($"Policy {policyId} not found.");
            if (updatedPolicy.PolicyId != policyId)
                throw new ArgumentException("Policy ID mismatch.");
            policies[policyId] = updatedPolicy;
        }

        public void DeletePolicy(int policyId)
        {
            if (!policies.ContainsKey(policyId))
                throw new PolicyNotFoundException($"Policy {policyId} not found.");
            policies.Remove(policyId);

        }

        public Policy SearchPolicy(int policyId)
        {
            if (!policies.ContainsKey(policyId))
                throw new PolicyNotFoundException("Policy not found.");
             return policies[policyId];
        }

        public List<Policy> GetAllPolicies()
        {
            return policies.Values.ToList();
        }

        public List<Policy> GetActivePolicies()
        {
           return policies.Values.Where(p => p.IsActive).ToList();
           
        }

        public List<Policy> GetInactivePolicies()
        {
            return policies.Values.Where(p => !p.IsActive).ToList();
        }

        public void TogglePolicyStatus(int policyId)
        {
            if (!policies.ContainsKey(policyId))
                throw new PolicyNotFoundException($"Policy with ID {policyId} not found.");

            var policy = policies[policyId];
            policy.IsActive = !policy.IsActive; // Toggle the status
        }
    }
}
