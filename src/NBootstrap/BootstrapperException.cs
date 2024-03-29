﻿// Copyright 2011, Ben Aston (ben@bj.ma).
// 
// This file is part of NBootstrap.
// 
// NBootstrap is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// NBootstrap is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with NBootstrap.  If not, see <http://www.gnu.org/licenses/>.

namespace NBootstrap
{
	using System;
	using NHelpfulException;

	public class BootstrapperException : HelpfulException
	{
		private const string DefaultMessage = "There was a problem bootstrapping the application.";

		public BootstrapperException(string problemDescription = default(string),
		                             Exception innerException = default(Exception))
			: base(DefaultMessage + " " + problemDescription ?? String.Empty, innerException: innerException) {}
	}
}