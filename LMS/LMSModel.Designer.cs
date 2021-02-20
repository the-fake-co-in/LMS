﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace LMS
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class LMSEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new LMSEntities object using the connection string found in the 'LMSEntities' section of the application configuration file.
        /// </summary>
        public LMSEntities() : base("name=LMSEntities", "LMSEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new LMSEntities object.
        /// </summary>
        public LMSEntities(string connectionString) : base(connectionString, "LMSEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new LMSEntities object.
        /// </summary>
        public LMSEntities(EntityConnection connection) : base(connection, "LMSEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<UserInfo> UserInfoes
        {
            get
            {
                if ((_UserInfoes == null))
                {
                    _UserInfoes = base.CreateObjectSet<UserInfo>("UserInfoes");
                }
                return _UserInfoes;
            }
        }
        private ObjectSet<UserInfo> _UserInfoes;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<UserMaster> UserMasters
        {
            get
            {
                if ((_UserMasters == null))
                {
                    _UserMasters = base.CreateObjectSet<UserMaster>("UserMasters");
                }
                return _UserMasters;
            }
        }
        private ObjectSet<UserMaster> _UserMasters;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the UserInfoes EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUserInfoes(UserInfo userInfo)
        {
            base.AddObject("UserInfoes", userInfo);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the UserMasters EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToUserMasters(UserMaster userMaster)
        {
            base.AddObject("UserMasters", userMaster);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="LMSModel", Name="UserInfo")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class UserInfo : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new UserInfo object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="userid">Initial value of the Userid property.</param>
        /// <param name="firstName">Initial value of the FirstName property.</param>
        /// <param name="lastName">Initial value of the LastName property.</param>
        /// <param name="gender">Initial value of the Gender property.</param>
        /// <param name="dateOfBirth">Initial value of the DateOfBirth property.</param>
        /// <param name="address2">Initial value of the Address2 property.</param>
        /// <param name="dateOfAdmission">Initial value of the DateOfAdmission property.</param>
        /// <param name="semester">Initial value of the Semester property.</param>
        public static UserInfo CreateUserInfo(global::System.Int32 id, global::System.Int32 userid, global::System.String firstName, global::System.String lastName, global::System.String gender, global::System.DateTime dateOfBirth, global::System.String address2, global::System.DateTime dateOfAdmission, global::System.Byte semester)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.Id = id;
            userInfo.Userid = userid;
            userInfo.FirstName = firstName;
            userInfo.LastName = lastName;
            userInfo.Gender = gender;
            userInfo.DateOfBirth = dateOfBirth;
            userInfo.Address2 = address2;
            userInfo.DateOfAdmission = dateOfAdmission;
            userInfo.Semester = semester;
            return userInfo;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Userid
        {
            get
            {
                return _Userid;
            }
            set
            {
                OnUseridChanging(value);
                ReportPropertyChanging("Userid");
                _Userid = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Userid");
                OnUseridChanged();
            }
        }
        private global::System.Int32 _Userid;
        partial void OnUseridChanging(global::System.Int32 value);
        partial void OnUseridChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                OnFirstNameChanging(value);
                ReportPropertyChanging("FirstName");
                _FirstName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("FirstName");
                OnFirstNameChanged();
            }
        }
        private global::System.String _FirstName;
        partial void OnFirstNameChanging(global::System.String value);
        partial void OnFirstNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String MiddleName
        {
            get
            {
                return _MiddleName;
            }
            set
            {
                OnMiddleNameChanging(value);
                ReportPropertyChanging("MiddleName");
                _MiddleName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("MiddleName");
                OnMiddleNameChanged();
            }
        }
        private global::System.String _MiddleName;
        partial void OnMiddleNameChanging(global::System.String value);
        partial void OnMiddleNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                OnLastNameChanging(value);
                ReportPropertyChanging("LastName");
                _LastName = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("LastName");
                OnLastNameChanged();
            }
        }
        private global::System.String _LastName;
        partial void OnLastNameChanging(global::System.String value);
        partial void OnLastNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                OnGenderChanging(value);
                ReportPropertyChanging("Gender");
                _Gender = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Gender");
                OnGenderChanged();
            }
        }
        private global::System.String _Gender;
        partial void OnGenderChanging(global::System.String value);
        partial void OnGenderChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime DateOfBirth
        {
            get
            {
                return _DateOfBirth;
            }
            set
            {
                OnDateOfBirthChanging(value);
                ReportPropertyChanging("DateOfBirth");
                _DateOfBirth = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DateOfBirth");
                OnDateOfBirthChanged();
            }
        }
        private global::System.DateTime _DateOfBirth;
        partial void OnDateOfBirthChanging(global::System.DateTime value);
        partial void OnDateOfBirthChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String MobileNo
        {
            get
            {
                return _MobileNo;
            }
            set
            {
                OnMobileNoChanging(value);
                ReportPropertyChanging("MobileNo");
                _MobileNo = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("MobileNo");
                OnMobileNoChanged();
            }
        }
        private global::System.String _MobileNo;
        partial void OnMobileNoChanging(global::System.String value);
        partial void OnMobileNoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String HomeContactNo
        {
            get
            {
                return _HomeContactNo;
            }
            set
            {
                OnHomeContactNoChanging(value);
                ReportPropertyChanging("HomeContactNo");
                _HomeContactNo = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("HomeContactNo");
                OnHomeContactNoChanged();
            }
        }
        private global::System.String _HomeContactNo;
        partial void OnHomeContactNoChanging(global::System.String value);
        partial void OnHomeContactNoChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Address1
        {
            get
            {
                return _Address1;
            }
            set
            {
                OnAddress1Changing(value);
                ReportPropertyChanging("Address1");
                _Address1 = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Address1");
                OnAddress1Changed();
            }
        }
        private global::System.String _Address1;
        partial void OnAddress1Changing(global::System.String value);
        partial void OnAddress1Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Address2
        {
            get
            {
                return _Address2;
            }
            set
            {
                OnAddress2Changing(value);
                ReportPropertyChanging("Address2");
                _Address2 = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Address2");
                OnAddress2Changed();
            }
        }
        private global::System.String _Address2;
        partial void OnAddress2Changing(global::System.String value);
        partial void OnAddress2Changed();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String City
        {
            get
            {
                return _City;
            }
            set
            {
                OnCityChanging(value);
                ReportPropertyChanging("City");
                _City = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("City");
                OnCityChanged();
            }
        }
        private global::System.String _City;
        partial void OnCityChanging(global::System.String value);
        partial void OnCityChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String State
        {
            get
            {
                return _State;
            }
            set
            {
                OnStateChanging(value);
                ReportPropertyChanging("State");
                _State = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("State");
                OnStateChanged();
            }
        }
        private global::System.String _State;
        partial void OnStateChanging(global::System.String value);
        partial void OnStateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Country
        {
            get
            {
                return _Country;
            }
            set
            {
                OnCountryChanging(value);
                ReportPropertyChanging("Country");
                _Country = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Country");
                OnCountryChanged();
            }
        }
        private global::System.String _Country;
        partial void OnCountryChanging(global::System.String value);
        partial void OnCountryChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Pincode
        {
            get
            {
                return _Pincode;
            }
            set
            {
                OnPincodeChanging(value);
                ReportPropertyChanging("Pincode");
                _Pincode = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Pincode");
                OnPincodeChanged();
            }
        }
        private global::System.String _Pincode;
        partial void OnPincodeChanging(global::System.String value);
        partial void OnPincodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime DateOfAdmission
        {
            get
            {
                return _DateOfAdmission;
            }
            set
            {
                OnDateOfAdmissionChanging(value);
                ReportPropertyChanging("DateOfAdmission");
                _DateOfAdmission = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DateOfAdmission");
                OnDateOfAdmissionChanged();
            }
        }
        private global::System.DateTime _DateOfAdmission;
        partial void OnDateOfAdmissionChanging(global::System.DateTime value);
        partial void OnDateOfAdmissionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Byte Semester
        {
            get
            {
                return _Semester;
            }
            set
            {
                OnSemesterChanging(value);
                ReportPropertyChanging("Semester");
                _Semester = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Semester");
                OnSemesterChanged();
            }
        }
        private global::System.Byte _Semester;
        partial void OnSemesterChanging(global::System.Byte value);
        partial void OnSemesterChanged();

        #endregion

    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="LMSModel", Name="UserMaster")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class UserMaster : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new UserMaster object.
        /// </summary>
        /// <param name="userId">Initial value of the UserId property.</param>
        /// <param name="isBlocked">Initial value of the IsBlocked property.</param>
        /// <param name="createdBy">Initial value of the CreatedBy property.</param>
        /// <param name="createdOn">Initial value of the CreatedOn property.</param>
        /// <param name="modifyBy">Initial value of the ModifyBy property.</param>
        /// <param name="modifyOn">Initial value of the ModifyOn property.</param>
        public static UserMaster CreateUserMaster(global::System.Int32 userId, global::System.Boolean isBlocked, global::System.Int32 createdBy, global::System.DateTime createdOn, global::System.Int32 modifyBy, global::System.DateTime modifyOn)
        {
            UserMaster userMaster = new UserMaster();
            userMaster.UserId = userId;
            userMaster.IsBlocked = isBlocked;
            userMaster.CreatedBy = createdBy;
            userMaster.CreatedOn = createdOn;
            userMaster.ModifyBy = modifyBy;
            userMaster.ModifyOn = modifyOn;
            return userMaster;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 UserId
        {
            get
            {
                return _UserId;
            }
            set
            {
                if (_UserId != value)
                {
                    OnUserIdChanging(value);
                    ReportPropertyChanging("UserId");
                    _UserId = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("UserId");
                    OnUserIdChanged();
                }
            }
        }
        private global::System.Int32 _UserId;
        partial void OnUserIdChanging(global::System.Int32 value);
        partial void OnUserIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                OnUserNameChanging(value);
                ReportPropertyChanging("UserName");
                _UserName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("UserName");
                OnUserNameChanged();
            }
        }
        private global::System.String _UserName;
        partial void OnUserNameChanging(global::System.String value);
        partial void OnUserNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                OnPasswordChanging(value);
                ReportPropertyChanging("Password");
                _Password = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Password");
                OnPasswordChanged();
            }
        }
        private global::System.String _Password;
        partial void OnPasswordChanging(global::System.String value);
        partial void OnPasswordChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                OnEmailChanging(value);
                ReportPropertyChanging("Email");
                _Email = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Email");
                OnEmailChanged();
            }
        }
        private global::System.String _Email;
        partial void OnEmailChanging(global::System.String value);
        partial void OnEmailChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Byte> FailAttempt
        {
            get
            {
                return _FailAttempt;
            }
            set
            {
                OnFailAttemptChanging(value);
                ReportPropertyChanging("FailAttempt");
                _FailAttempt = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("FailAttempt");
                OnFailAttemptChanged();
            }
        }
        private Nullable<global::System.Byte> _FailAttempt;
        partial void OnFailAttemptChanging(Nullable<global::System.Byte> value);
        partial void OnFailAttemptChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsBlocked
        {
            get
            {
                return _IsBlocked;
            }
            set
            {
                OnIsBlockedChanging(value);
                ReportPropertyChanging("IsBlocked");
                _IsBlocked = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsBlocked");
                OnIsBlockedChanged();
            }
        }
        private global::System.Boolean _IsBlocked;
        partial void OnIsBlockedChanging(global::System.Boolean value);
        partial void OnIsBlockedChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String BlockReason
        {
            get
            {
                return _BlockReason;
            }
            set
            {
                OnBlockReasonChanging(value);
                ReportPropertyChanging("BlockReason");
                _BlockReason = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("BlockReason");
                OnBlockReasonChanged();
            }
        }
        private global::System.String _BlockReason;
        partial void OnBlockReasonChanging(global::System.String value);
        partial void OnBlockReasonChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> LastLoginDate
        {
            get
            {
                return _LastLoginDate;
            }
            set
            {
                OnLastLoginDateChanging(value);
                ReportPropertyChanging("LastLoginDate");
                _LastLoginDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastLoginDate");
                OnLastLoginDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _LastLoginDate;
        partial void OnLastLoginDateChanging(Nullable<global::System.DateTime> value);
        partial void OnLastLoginDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> LastLogoutDate
        {
            get
            {
                return _LastLogoutDate;
            }
            set
            {
                OnLastLogoutDateChanging(value);
                ReportPropertyChanging("LastLogoutDate");
                _LastLogoutDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("LastLogoutDate");
                OnLastLogoutDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _LastLogoutDate;
        partial void OnLastLogoutDateChanging(Nullable<global::System.DateTime> value);
        partial void OnLastLogoutDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 CreatedBy
        {
            get
            {
                return _CreatedBy;
            }
            set
            {
                OnCreatedByChanging(value);
                ReportPropertyChanging("CreatedBy");
                _CreatedBy = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CreatedBy");
                OnCreatedByChanged();
            }
        }
        private global::System.Int32 _CreatedBy;
        partial void OnCreatedByChanging(global::System.Int32 value);
        partial void OnCreatedByChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime CreatedOn
        {
            get
            {
                return _CreatedOn;
            }
            set
            {
                OnCreatedOnChanging(value);
                ReportPropertyChanging("CreatedOn");
                _CreatedOn = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CreatedOn");
                OnCreatedOnChanged();
            }
        }
        private global::System.DateTime _CreatedOn;
        partial void OnCreatedOnChanging(global::System.DateTime value);
        partial void OnCreatedOnChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ModifyBy
        {
            get
            {
                return _ModifyBy;
            }
            set
            {
                OnModifyByChanging(value);
                ReportPropertyChanging("ModifyBy");
                _ModifyBy = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ModifyBy");
                OnModifyByChanged();
            }
        }
        private global::System.Int32 _ModifyBy;
        partial void OnModifyByChanging(global::System.Int32 value);
        partial void OnModifyByChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime ModifyOn
        {
            get
            {
                return _ModifyOn;
            }
            set
            {
                OnModifyOnChanging(value);
                ReportPropertyChanging("ModifyOn");
                _ModifyOn = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ModifyOn");
                OnModifyOnChanged();
            }
        }
        private global::System.DateTime _ModifyOn;
        partial void OnModifyOnChanging(global::System.DateTime value);
        partial void OnModifyOnChanged();

        #endregion

    
    }

    #endregion

    
}
