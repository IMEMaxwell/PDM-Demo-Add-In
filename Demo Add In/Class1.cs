using EPDM.Interop.epdm;
using System.Runtime.InteropServices;
using System;

namespace Demo_Add_In
{
    [Guid("83D6DED2-FB2D-4FED-A86B-A64F70C4F767"), ComVisible(true)]
    public class Class1 : IEdmAddIn5
    {
        public void GetAddInInfo(ref EdmAddInInfo poInfo, IEdmVault5 poVault, IEdmCmdMgr5 poCmdMgr)
        {
            poInfo.mlRequiredVersionMajor = 5;
            poInfo.mlRequiredVersionMinor = 2;
            poCmdMgr.AddHook(EdmCmdType.EdmCmd_PostAdd);
        }

        public void OnCmd(ref EdmCmd poCmd, ref EdmCmdData[] ppoData)
        {
            string name = "Post Add";
            string message = "The following files were affected by a " + name + " hook:" + ((EdmCmdData)(ppoData.GetValue(0))).mbsStrData1;

            EdmVault5 vault = default(EdmVault5);
            vault = (EdmVault5)poCmd.mpoVault;
            vault.MsgBox(poCmd.mlParentWnd, message);
        }
    }
}
