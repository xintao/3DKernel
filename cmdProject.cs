using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.Controls;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using Microsoft.Win32;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ArcScene;
using ESRI.ArcGIS.Analyst3D;
using ESRI.ArcGIS.ArcMapUI;

namespace ArcSceneKDE
{
    /// <summary>
    /// Command that works in ArcScene or SceneControl
    /// </summary>
    [Guid("255f3bc5-7053-438f-b9fb-0947aa6e5783")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcSceneKDE.cmdProject")]
    public sealed class cmdProject : BaseCommand
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
            SxCommands.Register(regKey);
            ControlsCommands.Register(regKey);
        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            SxCommands.Unregister(regKey);
            ControlsCommands.Unregister(regKey);
        }

        #endregion
        #endregion

        private IApplication m_application;
        private ISxDocument m_sxDoc;
        private IMap m_map;
        private ISceneHookHelper m_sceneHookHelper = null;

        public cmdProject()
        {
            //
            // TODO: Define values for the public properties
            //
            base.m_category = "KDE3D"; //localizable text
            base.m_caption = "3D Projection";  //localizable text 
            base.m_message = "Project 3D KDE to point or line features.";  //localizable text
            base.m_toolTip = "Project 3D KDE to point or line features.";  //localizable text
            base.m_name = "3D_Projection";   //unique id, non-localizable (e.g. "MyCategory_MyCommand")

            try
            {
                //
                // TODO: change bitmap name if necessary
                //
                //string bitmapResourceName = GetType().Name + ".bmp";
                //base.m_bitmap = new Bitmap(GetType(), bitmapResourceName);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message, "Invalid Bitmap");
            }
        }

        #region Overridden Class Methods

        /// <summary>
        /// Occurs when this command is created
        /// </summary>
        /// <param name="hook">Instance of the application</param>
        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

            m_application = hook as IApplication;
            try
            {
                m_sceneHookHelper = new SceneHookHelperClass();
                m_sceneHookHelper.Hook = hook;
                if (m_sceneHookHelper.ActiveViewer == null)
                {
                    m_sceneHookHelper = null;
                }
            }
            catch
            {
                m_sceneHookHelper = null;
            }

            if (m_sceneHookHelper == null)
                base.m_enabled = false;
            else
                base.m_enabled = true;

            // TODO:  Add other initialization code

        }

        /// <summary>
        /// Occurs when this command is clicked
        /// </summary>
        public override void OnClick()
        {
            // TODO: Add cmdProject.OnClick implementation
            m_sxDoc = (ISxDocument)m_application.Document;
            
            //FormProject pfrm = new FormProject();
            //pfrm.ShowDialog();
        }

        #endregion
    }
}
