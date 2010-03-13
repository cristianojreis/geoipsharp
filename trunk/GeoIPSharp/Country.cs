/**
 * Country.cs
 *
 * Copyright (C) 2008 MaxMind Inc.  All Rights Reserved.
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */
namespace MaxMind.GeoIP
{
    using System;

    public class Country : IEquatable<Country>
    {
        /// <summary>
        /// Gets the ISO two-letter country code of this country.
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// Gets the name of this country.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Creates a new Country.
        /// </summary>
        /// <param name="code">The country code.</param>
        /// <param name="name">The country name.</param>
        public Country(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Code, Name);
        }

        #region IEquatable<Country> Members

        public bool Equals(Country other)
        {
            return this.Code == other.Code && this.Name == other.Name;
        }

        #endregion

        public override bool Equals(object obj)
        {
            Country other = obj as Country;
            if (other == null) return false;
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return this.Code.GetHashCode() ^ this.Name.GetHashCode();
        }

        public static bool operator ==(Country a, Country b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Country a, Country b)
        {
            return !a.Equals(b);
        }
    }
}