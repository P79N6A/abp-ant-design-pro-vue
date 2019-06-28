﻿using System;
using System.Collections.Generic;
using Niue.Alipay.Response;

namespace Niue.Alipay.Request
{
    /// <summary>
    /// AOP API: alipay.ecapiprod.drawndn.drawndnlist.query
    /// </summary>
    public class AlipayEcapiprodDrawndnDrawndnlistQueryRequest : IAopRequest<AlipayEcapiprodDrawndnDrawndnlistQueryResponse>
    {
        /// <summary>
        /// 授信编号
        /// </summary>
        public string CreditNo { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string EntityCode { get; set; }

        /// <summary>
        /// 客户的姓名
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// 融资平台分配给ISV的编码
        /// </summary>
        public string IsvCode { get; set; }

        /// <summary>
        /// 融资平台分配给小贷公司的机构编码
        /// </summary>
        public string OrgCode { get; set; }

        #region IAopRequest Members
		private bool  needEncrypt=false;
        private string apiVersion = "1.0";
		private string terminalType;
		private string terminalInfo;
        private string prodCode;
		private string notifyUrl;
        private string returnUrl;
		private AopObject bizModel;

		public void SetNeedEncrypt(bool needEncrypt){
             this.needEncrypt=needEncrypt;
        }

        public bool GetNeedEncrypt(){

            return this.needEncrypt;
        }

		public void SetNotifyUrl(string notifyUrl){
            this.notifyUrl = notifyUrl;
        }

        public string GetNotifyUrl(){
            return this.notifyUrl;
        }

        public void SetReturnUrl(string returnUrl){
            this.returnUrl = returnUrl;
        }

        public string GetReturnUrl(){
            return this.returnUrl;
        }

        public void SetTerminalType(String terminalType){
			this.terminalType=terminalType;
		}

    	public string GetTerminalType(){
    		return this.terminalType;
    	}

    	public void SetTerminalInfo(String terminalInfo){
    		this.terminalInfo=terminalInfo;
    	}

    	public string GetTerminalInfo(){
    		return this.terminalInfo;
    	}

        public void SetProdCode(String prodCode){
            this.prodCode=prodCode;
        }

        public string GetProdCode(){
            return this.prodCode;
        }

        public string GetApiName()
        {
            return "alipay.ecapiprod.drawndn.drawndnlist.query";
        }

        public void SetApiVersion(string apiVersion){
            this.apiVersion=apiVersion;
        }

        public string GetApiVersion(){
            return this.apiVersion;
        }

        public IDictionary<string, string> GetParameters()
        {
            AopDictionary parameters = new AopDictionary();
            parameters.Add("credit_no", this.CreditNo);
            parameters.Add("entity_code", this.EntityCode);
            parameters.Add("entity_name", this.EntityName);
            parameters.Add("isv_code", this.IsvCode);
            parameters.Add("org_code", this.OrgCode);
            return parameters;
        }

		public AopObject GetBizModel()
        {
            return this.bizModel;
        }

        public void SetBizModel(AopObject bizModel)
        {
            this.bizModel = bizModel;
        }

        #endregion
    }
}