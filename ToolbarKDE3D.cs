using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.ADF.BaseClasses;

namespace ArcSceneKDE
{
    /// <summary>
    /// Summary description for KDE3DToolbar.
    /// </summary>
    [Guid("10ecf024-c925-4f48-b488-5900753b9782")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcSceneKDE.KDE3DToolbar")]
    public sealed class ToolbarKDE3D : BaseToolbar
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            SxCommandBars.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            SxCommandBars.Unregister(regKey);
        }

        #endregion
        #endregion

        public ToolbarKDE3D()
        {
            //
            // TODO: Define your toolbar here by adding items
            //
            AddItem("ArcSceneKDE.cmdKDE3DGen");
            BeginGroup(); //Separator
            AddItem("ArcSceneKDE.cmdAddLayers");
            BeginGroup(); //Separator
            AddItem("ArcSceneKDE.cmdExport");
            BeginGroup(); //Separator
            AddItem("ArcSceneKDE.cmdProject");         
            BeginGroup(); //Separator
            AddItem("ArcSceneKDE.cmdVectorizeCell");          
            BeginGroup(); //Separator
            AddItem("ArcSceneKDE.cmdPnt2Ln");
            BeginGroup(); //Separator
            AddItem("ArcSceneKDE.cmdGPS2Shp");
            
            //AddItem("{FBF8C3FB-0480-11D2-8D21-080009EE4E51}", 1); //undo command
            //AddItem(new Guid("FBF8C3FB-0480-11D2-8D21-080009EE4E51"), 2); //redo command
        }

        public override string Caption
        {
            get
            {
                //TODO: Replace bar caption
                return "3D KDE";
            }
        }
        public override string Name
        {
            get
            {
                //TODO: Replace bar ID
                return "KDE3DToolbar";
            }
        }
    }
}
