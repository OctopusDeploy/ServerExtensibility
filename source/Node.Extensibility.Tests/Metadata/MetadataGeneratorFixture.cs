using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Assent;
using Newtonsoft.Json;
using NUnit.Framework;
using Octopus.Data.Resources;
using Octopus.Data.Resources.Attributes;
using Octopus.Node.Extensibility.Metadata;

namespace Node.Extensibility.Tests.Metadata
{
    [TestFixture]
    public class MetadataGeneratorFixture
    {
        [Test]
        public void SettingsMetadataShouldBeCorrect()
        {
            IGenerateMetadata generator = new MetadataGenerator();

            var metadata = generator.GetMetadata(typeof(TopLevelResource));

            var serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            };

            var json = JsonConvert.SerializeObject(metadata, serializerSettings);

            this.Assent(json);

        }

        [Test]
        public void MetadataShouldHandleSelfReferences()
        {
            IGenerateMetadata generator = new MetadataGenerator();

            var metadata = generator.GetMetadata<SelfReferencingResource>();

            var serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            };

            var json = JsonConvert.SerializeObject(metadata, serializerSettings);

            this.Assent(json);
        }

        [Test]
        public void MetadataShouldHandleNavigationalProperties()
        {
            IGenerateMetadata generator = new MetadataGenerator();

            var metadata = generator.GetMetadata<ParentResource>();

            var serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            };

            var json = JsonConvert.SerializeObject(metadata, serializerSettings);

            this.Assent(json);
        }

        public void SettingsValuesShouldBeCorrect()
        {
            var resource = new TopLevelResource()
            {
                SecondLevelResource = new SecondLevelResource()
                {
                    SensitiveStringProperty = "String value",
                    BoolProperty = false,
                    IntArrayProperty = new[] { 1, 2, 3 },
                    NullableDateTimeOffsetProperty = null,
                    StringArrayProperty = new[] { "first", "second" },
                },
                DateTimeOffsetProperty = DateTime.Now,
                IntProperty = 4,
                NullableDateTimeProperty = null,
                NullableIntProperty = 5,
                ListOfStringProperty = new List<string> { "1st", "2nd", "3rd" },
            };
        }

        public enum TestEnum
        {
            First = 5,
            [System.ComponentModel.Description("2nd")]
            Second = 7,
            Third = 11,
            Fourth
        }

        public abstract class SettingsResource 
        {
            protected SettingsResource()
            {
                Id = GetType().Name;
            }

            public string Id { get; set; }

            public string SomeValue { get; set; }
        }

        public class SelfReferencingResource : SettingsResource
        {
            public string Name { get; set; }

            public SelfReferencingResource SelfReference { get; set; }
        }

        public class ParentResource : SettingsResource
        {
            public List<ChildResource> Children { get; set; }
        }

        public class ChildResource
        {
            public ParentResource Parent { get; set; }

            public int ChildIntProperty { get; set; }
        }


        public class TopLevelResource : SettingsResource
        {
            public SecondLevelResource SecondLevelResource { get; set; }

            [DisplayName("Duplicated 2nd Level")]
            [System.ComponentModel.Description("This 2nd-level resource has been duplicated")]
            public SecondLevelResource DuplicateSecondLevelResource { get; set; }

            [Required]
            public DateTime? NullableDateTimeProperty { get; set; }

            public DateTimeOffset DateTimeOffsetProperty { get; set; }

            public int IntProperty { get; set; }

            [HasOptions(SelectMode.Single)]
            public TestEnum EnumProp { get; set; }

            public int? NullableIntProperty { get; set; }

            public List<string> ListOfStringProperty { get; set; }

            public DateTime?[] NullableDateTimeArray { get; set; }

            [ReadOnly(true)]
            public string HandsOff { get; set; }
        }

        public class SecondLevelResource
        { 
            public SensitiveValue SensitiveStringProperty { get; set; }

            public DateTimeOffset? NullableDateTimeOffsetProperty { get; set; }

            public bool BoolProperty { get; set; }

            public string[] StringArrayProperty { get; set; }

            public int[] IntArrayProperty { get; set; }
        }
    }
}
