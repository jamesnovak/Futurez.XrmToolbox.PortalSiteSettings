﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Futurez.XrmToolBox
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Portal Site Settings Manager"),
        ExportMetadata("Description", "Manage all of Site Settings for a WebSite in a single editor"),
        ExportMetadata("BackgroundColor", "LightBlue"),
        ExportMetadata("PrimaryFontColor", "Black"),
        ExportMetadata("SecondaryFontColor", "Blue"),
        ExportMetadata("SmallImageBase64", "iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAfkAAAH5ABAK6ClwAAABl0RVh0U29mdHdhcmUAcGFpbnQubmV0IDQuMC4xMzQDW3oAAANuSURBVFhH7ZZ9SBNhHMfPpCCSwkoi292m9ldJkCEEFfRPKezunNBChDAqC6SIXra7my8z31IhCiVKKyLDImkRpmEoQi9CrihYRkIpScN8x/d0bnv63e2ZbXaTm0L0xz7w3XG3u9/39zz3e37PESFCLAuzeQX8gP4BlJaPJGkTo2aFAormLRTDv1Mz/Gc1y3eoWc4K1x5RtJCn0ZqSNh24sAY/tnR2naxaSdGGBIoVctSM0AaGDjBHSgTPOOD+VorlDCqtEO+ZqSCA0cZSDNcIQX7JGQQlhp+gWN4SS3MUDh+YKH1WBEVzeRQjTC8MtDezHJmr61GL9QvqHx5HTpcLBYPL5RpxOp2c2+1ei+382Uyf3wjZtsE7dfsax6Vmo8I7jWhkfAq5cbClAuZuSKQBDquxrYcovTkCpvu5r7GoxIwS1PDGJj6IQ8jjdLrQ0OgE6hseU6Ru+2BDaV3zOo87FAjJcDULzXcfK0Vd9kFsEZjO730o1XgDJRwpQjvSCxQrLjWnENzDCDJF2AdF4lds29PyUZutC1sE5pt9QErU91mlgpXyc0uyUUWoaa7S949YXTZ69tqGLQIz65hDKRev+wUNVrBMcwioeJvvxeNF99DcnBPbBObVx69Sgabn3ka5VfWKlVX2AMXoTJ4EwFtMYNI3gfaObmyxOIaKx9JsiUsyGCytH5AmxZsAPwsJ8GNe88Omanzb4ogVH592CZKw4CvKyci/Oz9YqL0pAtrse/FEHM3bT8pGX1bzAkYhoJtPXqJmaExKVdvULvl4EwBZxRm4LJ4kn61A0zMObBGYodFJlHi0xDfIUuUG79ME7GQ7YRamr9Q2Y4vFEVdIDH6HyxEsw55oHb9BakQanam4yz6gqNNmFt+XDRiceBg9d0ZqRCL6urpw6NEPsUdAfvSPSEtPPqhiuWH0V8E0XDL3Av1+PSRRA5ItBHE/MELVywRULHHZwesu36Y3r8K2/oBPOBhlgKY8tn/oHRyVerhcYEVi+F4NzR8k9Hr/kcsBCahhJq7BsQck1UZtk3W+gSiX+K75TljvxSRriMbhlQGeYaBIkB5yaIEdb0be5G+JUw3fiE9VWmPS1mSz/AdIsIiB1CnZ+0naeIrU8oUkK1TCtN6CzayKZPkKkhHy4WvqBLT2PapD5/w/OEKE+H8hiN/iVRvcA10DtAAAAABJRU5ErkJggg=="),
        ExportMetadata("BigImageBase64", "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")]
    public class PortalSiteSettings : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new PortalSiteSettingsControl();
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public PortalSiteSettings()
        {
            // If you have external assemblies that you need to load, uncomment the following to 
            // hook into the event that will fire when an Assembly fails to resolve
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}