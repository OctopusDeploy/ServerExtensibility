using System;
using System.Collections;
using System.Collections.Generic;
using Octopus.Data;

namespace Octopus.Server.Extensibility.HostServices.Model
{
    public class PackageReferenceCollection : ICollection<PackageReference>
    {
        readonly Dictionary<string, PackageReference> idMap = new Dictionary<string, PackageReference>(StringComparer.OrdinalIgnoreCase);

        readonly Dictionary<string, PackageReference> nameMap = new Dictionary<string, PackageReference>(StringComparer.OrdinalIgnoreCase);

        public PackageReferenceCollection()
        {
        }

        public PackageReferenceCollection(IEnumerable<PackageReference> packages)
        {
            foreach (var package in packages) Add(package);
        }

        public PackageReference? PrimaryPackage => nameMap.ContainsKey("") ? nameMap[""] : null;

        public bool HasPrimaryPackage => PrimaryPackage != null;

        public int Count => nameMap.Count;

        public bool IsReadOnly => false;

        public void Add(PackageReference item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (nameMap.ContainsKey(item.Name))
                throw new ArgumentException($"A package reference with the name '{item.Name}' already exists");

            if (idMap.ContainsKey(item.Id))
                throw new ArgumentException($"A package reference with the ID '{item.Id}' already exists");

            nameMap.Add(item.Name, item);
            idMap.Add(item.Id, item);
        }

        public bool Contains(PackageReference item)
        {
            return idMap.ContainsKey(item.Id);
        }

        public void CopyTo(PackageReference[] array, int arrayIndex)
        {
            nameMap.Values.CopyTo(array, arrayIndex);
        }

        public bool Remove(PackageReference item)
        {
            nameMap.Remove(item.Name);
            return idMap.Remove(item.Id);
        }

        public void Clear()
        {
            idMap.Clear();
            nameMap.Clear();
        }

        public IEnumerator<PackageReference> GetEnumerator()
        {
            return nameMap.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public PackageReference GetById(string id)
        {
            return idMap[id];
        }

        public PackageReference GetByName(string name)
        {
            var key = name ?? "";
            return nameMap[key];
        }

        public Result<PackageReference> TryGetByName(string name)
        {
            var key = name ?? "";
            return nameMap.ContainsKey(key) ? Result<PackageReference>.Success(nameMap[key]) : Result<PackageReference>.Failed();
        }

        public Result<PackageReference> TryGetById(string id)
        {
            return idMap.ContainsKey(id) ? Result<PackageReference>.Success(idMap[id]) : Result<PackageReference>.Failed();
        }

        public Result<PackageReference> TryGetByIdOrName(string idOrName)
        {
            var result = TryGetById(idOrName);
            if (result.WasSuccessful)
                return result;

            result = TryGetByName(idOrName);
            return result;
        }
    }
}