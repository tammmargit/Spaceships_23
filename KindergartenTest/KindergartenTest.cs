using System;
using Xunit;
using ShopTARge23.Core.Domain;

namespace ShopTARge23.Tests
{
    public class KindergartenTests
    {

        [Fact]
        public void Properties_ShouldAcceptAssignedValues()
        {
 
            var kindergarten = new Kindergarten();
            var testId = Guid.NewGuid();
            var groupName = "LPõrsad";
            var childrenCount = 20;
            var kindergartenName = "Linnukeste";
            var teacherName = "Linda";

            kindergarten.Id = testId;
            kindergarten.GroupName = groupName;
            kindergarten.ChildrenCount = childrenCount;
            kindergarten.KindergartenName = kindergartenName;
            kindergarten.Teacher = teacherName;

            Assert.Equal(testId, kindergarten.Id);
            Assert.Equal(groupName, kindergarten.GroupName);
            Assert.Equal(childrenCount, kindergarten.ChildrenCount);
            Assert.Equal(kindergartenName, kindergarten.KindergartenName);
            Assert.Equal(teacherName, kindergarten.Teacher);
        }

        [Fact]
        public void Constructor_ShouldCreateEmptyKindergartenObject()
        {

            var kindergarten = new Kindergarten();

            Assert.NotNull(kindergarten);
            Assert.Null(kindergarten.Id);
            Assert.Null(kindergarten.GroupName);
            Assert.Equal(0, kindergarten.ChildrenCount);
            Assert.Null(kindergarten.KindergartenName);
            Assert.Null(kindergarten.Teacher);
            Assert.Equal(DateTime.MinValue, kindergarten.CreatedAt);
            Assert.Equal(DateTime.MinValue, kindergarten.UpdatedAt);
        }

        [Fact]
        public void CreatedAt_ShouldCaptureCurrentDateTime()
        {

            var kindergarten = new Kindergarten();
            var timestamp = DateTime.UtcNow;

           kindergarten.CreatedAt = timestamp;

            Assert.InRange(kindergarten.CreatedAt, timestamp.AddSeconds(-1), timestamp.AddSeconds(1));
        }

        [Fact]
        public void UpdatedAt_ShouldCaptureRecentDateTimeChange()
        {
            var kindergarten = new Kindergarten();
            var time = DateTime.UtcNow;
 
            kindergarten.UpdatedAt = time;

            Assert.InRange(kindergarten.UpdatedAt, time.AddSeconds(-1), time.AddSeconds(1));
        }
    }
}
