/*
	This file is part of Retractable Lifting Surface /L Unleashed
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

namespace RetractableLiftingSurface
{
	internal static class Log
	{
		private static readonly Logger LOG = Logger.CreateForType<RetractableLiftingSurface>();

		internal static void force(string msg, params object[] @params)
		{
			LOG.force(msg, @params);
		}

		internal static void error(string msg, params object[] @params)
		{
			LOG.error(msg, @params);
		}

		internal static void warn(string msg, params object[] @params)
		{
			LOG.warn(msg, @params);
		}

		[Conditional("DEBUG")]	
		internal static void dbg(string msg, params object[] @params)
		{
			LOG.dbg(msg, @params);
		}
	}
}
