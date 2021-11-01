/*
	This file is part of Deployable Aero Surfaces /L Unleashed
		© 2018-2021 Lisias T : http://lisias.net <support@lisias.net>

	THIS FILE is licensed to you under:

		* WTFPL - http://www.wtfpl.net
			* Everyone is permitted to copy and distribute verbatim or modified
 				copies of this license document, and changing it is allowed as long
				as the name is changed.

	THIS FILE is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
*/
using System.Diagnostics;

using KSPe.Util.Log;

namespace DeployableAeroSurfaces
{
	public static class Log
	{
		private static readonly Logger LOG = Logger.CreateForType<Startup>();

		public static void force(string msg, params object[] @params)
		{
			LOG.force(msg, @params);
		}

		public static void error(string msg, params object[] @params)
		{
			LOG.error(msg, @params);
		}

		public static void warn(string msg, params object[] @params)
		{
			LOG.warn(msg, @params);
		}

		[Conditional("DEBUG")]	
		public static void dbg(string msg, params object[] @params)
		{
			LOG.dbg(msg, @params);
		}
	}
}
