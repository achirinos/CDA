using CdaGenerator;

namespace GenerateReport
{
	using System;
	using System.ComponentModel;
	using System.Drawing;
	using Telerik.Reporting;
	using Telerik.Reporting.Drawing;

	/// <summary>
	/// Summary description for Report1.
	/// </summary>
	public partial class ResponseTemplate : Telerik.Reporting.Report
	{
		public ResponseTemplate(CdaResponse cda)
		{
			//
			// Required for telerik Reporting designer support
			//
			InitializeComponent();

		    this.DataSource = cda;
		}
	}
}