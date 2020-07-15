using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace Cms.Domain.UnitTests.Helpers
{
    class DefaultTestData : AutoDataAttribute
    {
        public DefaultTestData() : base(GetDefaultFixture)
        {
            
        }

        public static IFixture GetDefaultFixture()
        {
            return new Fixture()
                .Customize(new AutoMoqCustomization());
        }
    }
}
