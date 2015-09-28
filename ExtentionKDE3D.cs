using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ADF.CATIDs;

namespace ArcSceneKDE
{
    [Guid("b2760f7f-e3e8-425a-ab49-5d06fa6620d7")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ArcSceneKDE.KDE3DExt")]
    public class ExtentionKDE3D : IExtension, IExtensionConfig, IPersistVariant
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
            SxExtensions.Register(regKey);

        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            SxExtensions.Unregister(regKey);

        }

        #endregion
        #endregion
        private IApplication m_application;
        private esriExtensionState m_enableState;

        /// <summary>
        /// Determine extension state 
        /// </summary>
        /// <param name="requestEnable">true if to enable; false to disable</param>
        private esriExtensionState StateCheck(bool requestEnable)
        {
            //TODO: Replace with advanced extension state checking if needed
            //Turn on or off extension directly 
            if (requestEnable)
                return esriExtensionState.esriESEnabled;
            else
                return esriExtensionState.esriESDisabled;
        }

        #region IExtension Members

        /// <summary>
        /// Name of extension. Do not exceed 31 characters
        /// </summary>
        public string Name
        {
            get
            {
                //TODO: Modify string to uniquely identify extension
                return "KDE3DExt";
            }
        }

        public void Shutdown()
        {
            //TODO: Clean up resources

            m_application = null;
        }

        public void Startup(ref object initializationData)
        {
            m_application = initializationData as IApplication;
            if (m_application == null)
                return;

            //TODO: Add code to initialize the extension
        }

        #endregion

        #region IExtensionConfig Members

        public string Description
        {
            get
            {
                //TODO: Replace description (use \r\n for line break)
                return "KDE3DExt\r\n" +
                    "Copyright ?Civil Engineering R.U. 2015\r\n\r\n" +
                    "Provides a complete set of tools to create, maintain, and perform 3D kernel density analysis.\r\n"
                    + "Refer to http://translab.civil.ryerson.ca for more details.\r\n"
                    + "\r\n"
                    + "Contributors: J. Chow and X. Liu";
            }
        }

        /// <summary>
        /// Friendly name shown in the Extensions dialog
        /// </summary>
        public string ProductName
        {
            get
            {
                //TODO: Replace
                return "KDE3D";
            }
        }

        public esriExtensionState State
        {
            get
            {
                return m_enableState;
            }
            set
            {
                if (m_enableState != 0 && value == m_enableState)
                    return;

                //Check if ok to enable or disable extension
                esriExtensionState requestState = value;
                if (requestState == esriExtensionState.esriESEnabled)
                {
                    //Cannot enable if it's already in unavailable state
                    if (m_enableState == esriExtensionState.esriESUnavailable)
                    {
                        throw new COMException("Cannot enable extension");
                    }

                    //Determine if state can be changed
                    esriExtensionState checkState = StateCheck(true);
                    m_enableState = checkState;
                }
                else if (requestState == 0 || requestState == esriExtensionState.esriESDisabled)
                {
                    //Determine if state can be changed
                    esriExtensionState checkState = StateCheck(false);
                    if (checkState != m_enableState)
                        m_enableState = checkState;
                }

            }
        }

        #endregion

        #region IPersistVariant Members

        public UID ID
        {
            get
            {
                UID typeID = new UIDClass();
                typeID.Value = GetType().GUID.ToString("B");
                return typeID;
            }
        }

        public void Load(IVariantStream Stream)
        {
            //TODO: Load persisted data from document stream

            Marshal.ReleaseComObject(Stream);
        }

        public void Save(IVariantStream Stream)
        {
            //TODO: Save extension related data to document stream

            Marshal.ReleaseComObject(Stream);
        }

        #endregion
    }
}
