using DisasterPOEApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DisasterPOEApp.Controllers;
using DisasterPOEApp.Models;
using System.Collections;
using FakeItEasy;
using FluentAssertions;
using Moq;
using System.Web.Mvc;

namespace DisasterPOEApp.Test.DisasterTests
{
    public class DisasterPOETests
    {
        [Fact]
        public void AllocateResources_Should_Return_Correct_Strings_And_Ints()
        {
            // Arrange
            var disasterId = 1;
            var amountAllocated = 100;
            var resource = "Food";
            var resourceAmount = 50;
            var allocationDate = DateTime.Now;

            var resourceAllocator = new ResourceAllocator();

            // Act
            var result = resourceAllocator.AllocateResources(disasterId, amountAllocated, resource, resourceAmount, allocationDate);

            // Assert
            result.Should().NotBeNull();
            result.DisasterId.Should().Be(disasterId);
            result.AmountAllocated.Should().Be(amountAllocated);
            result.Resource.Should().Be(resource);
            result.ResourceAmount.Should().Be(resourceAmount);
            result.AllocationDate.Should().Be(allocationDate);
        }
    }

    // Example ResourceAllocator class for demonstration purposes
    public class ResourceAllocator
    {
        public ResourceAllocation AllocateResources(int disasterId, int amountAllocated, string resource, int resourceAmount, DateTime allocationDate)
        {
            // Some logic to allocate resources...
            return new ResourceAllocation
            {
                DisasterId = disasterId,
                AmountAllocated = amountAllocated,
                Resource = resource,
                ResourceAmount = resourceAmount,
                AllocationDate = allocationDate
            };
        }
    }

    // Example ResourceAllocation class for demonstration purposes
    public class ResourceAllocation
    {
        public int DisasterId { get; set; }
        public int AmountAllocated { get; set; }
        public string Resource { get; set; }
        public int ResourceAmount { get; set; }
        public DateTime AllocationDate { get; set; }
    }

}

