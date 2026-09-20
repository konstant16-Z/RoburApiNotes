using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using Topomatic.FoundationClasses;
using \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0089;
using \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008b;
using \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093;
using \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b;

namespace Topomatic.Cadastre;

public sealed class Cadastre : UpdatableObject, IOwned
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass1
	{
		public Cadastre <>4__this;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass1()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadDetailsRequestNode>b__0()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3422))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0090 = reader.ReadElementContentAsString();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4
	{
		public Cadastre <>4__this;

		public Parcel parcel;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass4()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadLandRecordNode>b__3()
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(80))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3468))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0089(parcel, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3494))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009c(parcel, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3516))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008b(parcel, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3532))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008e(parcel, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3548))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0087(parcel, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3584))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0099(parcel, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3612))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0092(parcel, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3650))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0098(parcel, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3704))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008d(parcel, reader);
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7
	{
		public Cadastre <>4__this;

		public global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008a cadastralObject;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass7()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadRecordInfoNode>b__6()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3716))
			{
				cadastralObject.RegistrationDate = reader.ReadElementContentAsString();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassa
	{
		public Cadastre <>4__this;

		public CadastralObject obj;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassa()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadCommonDataNode>b__9()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3754))
			{
				obj.CadastralNumber = new CadastralNumber(reader.ReadElementContentAsString());
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3778))
			{
				obj.QuarterNumber = new CadastralNumber(reader.ReadElementContentAsString());
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3818))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassd
	{
		public Cadastre <>4__this;

		public CadastralObject obj;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassd()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadObjectNode>b__c()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3830))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008a(obj, reader);
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3856))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass10
	{
		public Cadastre <>4__this;

		public global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0089.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088 obj;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass10()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadAreaNode>b__f()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3874))
			{
				obj.Area = reader.ReadElementContentAsString();
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3888))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass13
	{
		public Cadastre <>4__this;

		public CadastralObject obj;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass13()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadCostNode>b__12()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3900))
			{
				obj.Cost = reader.ReadElementContentAsDouble();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass16
	{
		public Cadastre <>4__this;

		public Parcel parcel;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass16()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadParamsNode>b__15()
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(84))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3914))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008c(parcel, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3926))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008f(parcel, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3946))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0090(parcel, reader);
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass19
	{
		public Cadastre <>4__this;

		public Parcel parcel;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass19()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadCategoryNode>b__18()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3976))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0094(parcel.Category, reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass1c
	{
		public Cadastre <>4__this;

		public Parcel parcel;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass1c()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadPermittedUseNode>b__1b()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3988))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0091(parcel, reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass1f
	{
		public Cadastre <>4__this;

		public Parcel parcel;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass1f()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadPermittedUseEstablishedNode>b__1e()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4042))
			{
				parcel.PermittedUses.Add(reader.ReadElementContentAsString());
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass22
	{
		public Cadastre <>4__this;

		public Construction construction;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass22()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadParamsNode>b__21()
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(88))
			{
				return;
			}
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4068))
			{
				construction.Area = reader.ReadElementContentAsString();
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4080))
			{
				construction.Floors = (byte)reader.ReadElementContentAsInt();
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4096))
			{
				string s = reader.ReadElementContentAsString();
				if (byte.TryParse(s, out var result))
				{
					construction.UndergroundFloors = result;
				}
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4136))
			{
				construction.YearBuilt = (ushort)reader.ReadElementContentAsInt();
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4160))
			{
				construction.YearCommisioning = (ushort)reader.ReadElementContentAsInt();
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4198))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0094(construction.Purpose, reader);
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4216))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093(construction, reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass25
	{
		public Cadastre <>4__this;

		public Construction construction;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass25()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadPermittedUsesNode>b__24()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4248))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0094(construction, reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass28
	{
		public Cadastre <>4__this;

		public Construction construction;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass28()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadPermittedUseNode>b__27()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4278))
			{
				construction.PermittedUses.Add(reader.ReadElementContentAsString());
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass2b
	{
		public Cadastre <>4__this;

		public Address address;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass2b()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadRegionNode>b__2a()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4290))
			{
				address.Region = reader.ReadElementContentAsString();
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4304))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass2e
	{
		public Cadastre <>4__this;

		public Address address;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass2e()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadDistrictNode>b__2d()
		{
			address.District = new Address.TypedString();
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4316))
			{
				address.District.Value = reader.ReadElementContentAsString();
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4346))
			{
				address.District.Type = reader.ReadElementContentAsString();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass31
	{
		public Cadastre <>4__this;

		public Address address;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass31()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadCityNode>b__30()
		{
			address.City = new Address.TypedString();
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4376))
			{
				address.City.Value = reader.ReadElementContentAsString();
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4398))
			{
				address.City.Type = reader.ReadElementContentAsString();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass34
	{
		public Cadastre <>4__this;

		public Address address;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass34()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadStreetNode>b__33()
		{
			address.Street = new Address.TypedString();
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4420))
			{
				address.Street.Value = reader.ReadElementContentAsString();
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4446))
			{
				address.Street.Type = reader.ReadElementContentAsString();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass37
	{
		public Cadastre <>4__this;

		public Address address;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass37()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadLevel1Node>b__36()
		{
			address.Level1 = new Address.TypedString();
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4472))
			{
				address.Level1.Value = reader.ReadElementContentAsString();
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4498))
			{
				address.Level1.Type = reader.ReadElementContentAsString();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass3a
	{
		public Cadastre <>4__this;

		public Address address;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass3a()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadLevel2Node>b__39()
		{
			address.Level2 = new Address.TypedString();
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4524))
			{
				address.Level2.Value = reader.ReadElementContentAsString();
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4550))
			{
				address.Level2.Type = reader.ReadElementContentAsString();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass3d
	{
		public Cadastre <>4__this;

		public Address address;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass3d()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadApartmentNode>b__3c()
		{
			address.Apartment = new Address.TypedString();
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4576))
			{
				address.Apartment.Value = reader.ReadElementContentAsString();
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4608))
			{
				address.Apartment.Type = reader.ReadElementContentAsString();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass40
	{
		public Cadastre <>4__this;

		public Address address;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass40()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadLevelSettlementNode>b__3f()
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(92))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4640))
				{
					address.OKATO = reader.ReadElementContentAsString();
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4654))
				{
					address.KLADR = reader.ReadElementContentAsString();
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4668))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0095(address, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4684))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0096(address, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4704))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0097(address, reader);
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass43
	{
		public Cadastre <>4__this;

		public Address address;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass43()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadDetailedLevelNode>b__42()
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(96))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4716))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0098(address, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4732))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0099(address, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4748))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a(address, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4764))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b(address, reader);
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass46
	{
		public Cadastre <>4__this;

		public Address address;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass46()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadAddressFiasNode>b__45()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4786))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009c(address, reader);
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4822))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009d(address, reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass49
	{
		public Cadastre <>4__this;

		public Address address;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass49()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadAddressNode>b__48()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4854))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009e(address, reader);
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4882))
			{
				address.ReadableAddress = reader.ReadElementContentAsString();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4c
	{
		public Cadastre <>4__this;

		public object obj;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass4c()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadAddressLocationNode>b__4b()
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(100))
			{
				return;
			}
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4918))
			{
				if (obj is Parcel)
				{
					Address address = new Address();
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0086(address, reader);
					((Parcel)obj).Addresses.Add(address);
				}
				else if (obj is Construction)
				{
					Construction construction = (Construction)obj;
					_ = construction.Address;
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0086(construction.Address, reader);
				}
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass4f
	{
		public Cadastre <>4__this;

		public SpelementUnit spelementUnit;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass4f()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadOrdinateNode>b__4e()
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(104))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4936))
				{
					spelementUnit.X = reader.ReadElementContentAsDouble();
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4942))
				{
					spelementUnit.Y = reader.ReadElementContentAsDouble();
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4948))
				{
					spelementUnit.Number = reader.ReadElementContentAsInt();
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4966))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4994))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass52
	{
		public Cadastre <>4__this;

		public SpatialElement spatialElement;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass52()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadOrdinatesNode>b__51()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5026))
			{
				SpelementUnit spelementUnit = new SpelementUnit();
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0088(spelementUnit, reader);
				spatialElement.Add(spelementUnit);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass55
	{
		public Cadastre <>4__this;

		public SpatialElement spatialElement;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass55()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadSpatialElementNode>b__54()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5046))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0089(spatialElement, reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass58
	{
		public Cadastre <>4__this;

		public EntitySpatial entitySpatial;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass58()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadSpatialElementsNode>b__57()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5068))
			{
				SpatialElement spatialElement = new SpatialElement(entitySpatial);
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008a(spatialElement, reader);
				entitySpatial.Elements.Add(spatialElement);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5b
	{
		public Cadastre <>4__this;

		public EntitySpatial entitySpatial;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass5b()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadEntitySpatialNode>b__5a()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5102))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008b(entitySpatial, reader);
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5140))
			{
				entitySpatial.Sk_Id = reader.ReadElementContentAsString();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass5e
	{
		public Cadastre <>4__this;

		public Boundary boundary;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass5e()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadContourNode>b__5d()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5154))
			{
				EntitySpatial entitySpatial = new EntitySpatial(boundary);
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008c(entitySpatial, reader);
				boundary.Add(entitySpatial);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass61
	{
		public Cadastre <>4__this;

		public EntitySpatial spatial;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass61()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadContourNode>b__60()
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(108))
			{
				return;
			}
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5186))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008c(spatial, reader);
				Borders borders = new Borders();
				foreach (SpatialElement element in spatial.Elements)
				{
					for (int i = 0; i < element.Count - 1; i++)
					{
						borders.Add(new Border
						{
							Spatial = spatial.Elements.Count - 1,
							Point1 = element[i].Number,
							Point2 = element[i + 1].Number
						});
					}
				}
				spatial.Borders.Add(borders);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass64
	{
		public Cadastre <>4__this;

		public EntitySpatial spatial;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass64()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadContoursNode>b__63()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5218))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008e(spatial, reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass67
	{
		public Cadastre <>4__this;

		public Bound bound;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass67()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadContoursNode>b__66()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5236))
			{
				Boundary boundary = new Boundary(bound);
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008d(boundary, reader);
				bound.Boundaries.Add(boundary);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6a
	{
		public Cadastre <>4__this;

		public LandPlotPart subParcel;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass6a()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadObjectPartNode>b__69()
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(112))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5254))
				{
					subParcel.Date = reader.ReadElementContentAsString();
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5278))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008f(subParcel.Spatial, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5298))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008c(subParcel, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5310))
				{
					subParcel.Number = reader.ReadElementContentAsString();
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5336))
				{
					subParcel.Mnemonic = reader.ReadElementContentAsString();
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5356))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass6d
	{
		public Cadastre <>4__this;

		public Parcel parcel;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass6d()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadContoursLocationNode>b__6c()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5400))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008f(parcel.Spatial, reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass70
	{
		public Cadastre <>4__this;

		public Bound bound;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass70()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadBContoursLocationNode>b__6f()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5420))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0090(bound, reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass73
	{
		public CadastralType type;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass73()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadTypeNode>b__72()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5440))
			{
				type.Code = reader.ReadElementContentAsString();
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5452))
			{
				type.Value = reader.ReadElementContentAsString();
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass76
	{
		public Cadastre <>4__this;

		public Restriction restriction;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass76()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadRestrictionEncumbranceNode>b__75()
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(116))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5466))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0094(restriction.Type, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5502))
				{
					restriction.PartNumber = reader.ReadElementContentAsString();
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5528))
				{
					restriction.Content = reader.ReadElementContentAsString();
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5590))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0096(restriction, reader);
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass79
	{
		public Cadastre <>4__this;

		public Restriction restriction;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass79()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadCadLinkNode>b__78()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5610))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0097(restriction, reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7c
	{
		public Cadastre <>4__this;

		public Restriction restriction;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass7c()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadRegNumberBorderNode>b__7b()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5648))
			{
				restriction.RegNumberBorder = reader.ReadElementContentAsString();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass7f
	{
		public Cadastre <>4__this;

		public Parcel parcel;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass7f()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadRestrictionsEncumbrancesNode>b__7e()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5664))
			{
				Restriction restriction = new Restriction();
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0095(restriction, reader);
				parcel.Restrictions.Add(restriction);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass82
	{
		public Cadastre <>4__this;

		public Parcel parcel;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass82()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadObjectPartsNode>b__81()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5714))
			{
				LandPlotPart landPlotPart = new LandPlotPart(parcel);
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0091(landPlotPart, reader);
				parcel.AddSubParcel(landPlotPart);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass85
	{
		public Cadastre <>4__this;

		public Construction construction;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass85()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadBuildRecordNode>b__84()
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(120))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5740))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0089(construction, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5766))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008b(construction, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5782))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009b(construction, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5804))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092(construction, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5820))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0087(construction, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5856))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008f(construction.Spatial, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5876))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008d(construction, reader);
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass88
	{
		public Cadastre <>4__this;

		public Construction construction;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass88()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadCadLinksNode>b__87()
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(124))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5888))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0086(construction, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5914))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009d(construction.LandCadNumbers, reader, global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5950));
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5984))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009d(construction.AscendantCadNumbers, reader, global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6030));
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6074))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009d(construction.DescendantCadNumbers, reader, global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6122));
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8b
	{
		public Cadastre <>4__this;

		public Parcel landPlot;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass8b()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadCadLinksNode>b__8a()
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(128))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6170))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0086(landPlot, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6196))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009d(landPlot.IncludedObjects, reader, global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6232));
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6266))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009d(landPlot.AscendantCadNumbers, reader, global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6312));
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6356))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009d(landPlot.DescendantCadNumbers, reader, global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6404));
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass8e
	{
		public Cadastre <>4__this;

		public IList<CadastralNumber> collection;

		public XmlTextReader reader;

		public string nodeName;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass8e()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadCadNumbersNode>b__8d()
		{
			if (reader.LocalName == nodeName)
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009e(collection, reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass91
	{
		public Cadastre <>4__this;

		public IList<CadastralNumber> collection;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass91()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadCadNumberNode>b__90()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6450))
			{
				collection.Add(new CadastralNumber(reader.ReadElementContentAsString()));
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass94
	{
		public Cadastre <>4__this;

		public CadastralObject cadastralObject;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass94()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadOldNumbersNode>b__93()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6474))
			{
				OldNumber oldNumber = new OldNumber();
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0087(oldNumber, reader);
				cadastralObject.OldNumbers.Add(oldNumber);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass97
	{
		public Cadastre <>4__this;

		public OldNumber oldNumber;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass97()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadOldNumberNode>b__96()
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(132))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6498))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0094(oldNumber.Type, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6524))
				{
					oldNumber.Number = reader.ReadElementString();
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6540))
				{
					oldNumber.AssignmentDate = reader.ReadElementString();
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6574))
				{
					oldNumber.Assigner = reader.ReadElementString();
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9a
	{
		public Cadastre <>4__this;

		public XmlTextReader reader;

		public CadastralNumber quarterNumber;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass9a()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadLandRecordsNode>b__99()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6594))
			{
				Parcel parcel = new Parcel();
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(parcel, reader);
				parcel.QuarterNumber = quarterNumber;
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0091.Add(parcel);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9d
	{
		public Cadastre <>4__this;

		public XmlTextReader reader;

		public CadastralNumber quarterNumber;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass9d()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadBuildRecordsNode>b__9c()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6620))
			{
				Construction construction = new Construction
				{
					ConstructionType = ConstructionType.Building,
					QuarterNumber = quarterNumber
				};
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009a(construction, reader);
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0094.Add(construction);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassa0
	{
		public Cadastre <>4__this;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassa0()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadConstructionRecordsNode>b__9f()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6648))
			{
				Construction construction = new Construction
				{
					ConstructionType = ConstructionType.Construction
				};
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009a(construction, reader);
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0094.Add(construction);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassa3
	{
		public Cadastre <>4__this;

		public XmlTextReader reader;

		public CadastralNumber quarterNumber;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassa3()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadBaseDataNode>b__a2()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6690))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0088(reader, quarterNumber);
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6718))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0089(reader, quarterNumber);
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6748))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008a(reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassa6
	{
		public Cadastre <>4__this;

		public XmlTextReader reader;

		public CadastralNumber quarterNumber;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassa6()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadRecordDataNode>b__a5()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6792))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008b(reader, quarterNumber);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassa9
	{
		public Cadastre <>4__this;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassa9()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadSpatialDataNode>b__a8()
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(136))
			{
				return;
			}
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6814))
			{
				EntitySpatial entitySpatial = new EntitySpatial(<>4__this);
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0092.Add(entitySpatial);
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008c(entitySpatial, reader);
				Borders borders = new Borders();
				foreach (SpatialElement element in entitySpatial.Elements)
				{
					for (int i = 0; i < element.Count - 1; i++)
					{
						borders.Add(new Border
						{
							Spatial = entitySpatial.Elements.Count - 1,
							Point1 = element[i].Number,
							Point2 = element[i + 1].Number
						});
					}
				}
				entitySpatial.Borders.Add(borders);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassac
	{
		public Cadastre <>4__this;

		public Bound bound;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassac()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadBObjectNode>b__ab()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6846))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0094(bound.Type, reader);
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6876))
			{
				bound.RegNumbBorder = reader.ReadElementContentAsString();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassaf
	{
		public Cadastre <>4__this;

		public Bound bound;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassaf()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadBObjectMunicipalBoundariesNode>b__ae()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6910))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008e(bound, reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassb2
	{
		public Cadastre <>4__this;

		public ZoneBound bound;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassb2()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadBObjectZonesAndTerritoriesNode>b__b1()
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(140))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6930))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008e(bound, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6950))
				{
					bound.Index = reader.ReadElementContentAsString();
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6964))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0094(bound.TypeZone, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6986))
				{
					bound.Number = reader.ReadElementContentAsString();
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassb5
	{
		public Cadastre <>4__this;

		public CoastlineBound bound;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassb5()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadBObjectZonesAndTerritoriesNode>b__b4()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7002))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008e(bound, reader);
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7022))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0092(bound, reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassb8
	{
		public Cadastre <>4__this;

		public CoastlineBound bound;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassb8()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadWaterNode>b__b7()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7036))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0094(bound.WaterObjectType, reader);
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7074))
			{
				bound.WaterObjectName = reader.ReadElementContentAsString();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassbb
	{
		public Cadastre <>4__this;

		public Bound bound;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassbb()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadMunicipalBoundaryRecordNode>b__ba()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7112))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0093(bound, reader);
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7154))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008f(bound, reader);
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7212))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassbe
	{
		public Cadastre <>4__this;

		public Bound bound;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassbe()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadInhabitedLocalityBoundaryRecordNode>b__bd()
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(144))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7238))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0093(bound, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7280))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008f(bound, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7356))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0096(bound, reader);
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassc1
	{
		public Cadastre <>4__this;

		public CoastlineBound bound;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassc1()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadCoastlineRecordNode>b__c0()
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(148))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7382))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0093(bound, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7424))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0091(bound, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7488))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0096(bound, reader);
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassc4
	{
		public Cadastre <>4__this;

		public Bound bound;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassc4()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadRecordInfoNode>b__c3()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7514))
			{
				bound.RegistrationDate = reader.ReadElementContentAsString();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassc7
	{
		public Cadastre <>4__this;

		public ZoneBound bound;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassc7()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadZonesAndTerritoriesRecordNode>b__c6()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7552))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0093(bound, reader);
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7594))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0090(bound, reader);
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7658))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassca
	{
		public Cadastre <>4__this;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassca()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadZonesAndTerritoriesBoundariesNode>b__c9()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7684))
			{
				ZoneBound zoneBound = new ZoneBound();
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0097(zoneBound, reader);
				if (zoneBound.RegNumbBorder != string.Empty)
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0093[zoneBound.RegNumbBorder] = zoneBound;
				}
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClasscd
	{
		public Cadastre <>4__this;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClasscd()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadMunicipalBoundariesNode>b__cc()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7744))
			{
				Bound bound = new Bound(BoundType.Municipal);
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0093(bound, reader);
				if (bound.RegNumbBorder != string.Empty)
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0093[bound.RegNumbBorder] = bound;
				}
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassd0
	{
		public Cadastre <>4__this;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassd0()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadInhabitedLocalityBoundariesNode>b__cf()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7798))
			{
				Bound bound = new Bound(BoundType.InhabitedLocality);
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0094(bound, reader);
				if (bound.RegNumbBorder != string.Empty)
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0093[bound.RegNumbBorder] = bound;
				}
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassd3
	{
		public Cadastre <>4__this;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassd3()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadCoastlineBoundariesNode>b__d2()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7870))
			{
				CoastlineBound coastlineBound = new CoastlineBound();
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0095(coastlineBound, reader);
				if (coastlineBound.RegNumbBorder != string.Empty)
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0093[coastlineBound.RegNumbBorder] = coastlineBound;
				}
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassd6
	{
		public CadastralNumber quarterNumber;

		public Cadastre <>4__this;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassd6()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadCadastralBlockNode>b__d5()
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(152))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7906))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008c(reader, quarterNumber);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7932))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008d(reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7960))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0098(reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8028))
				{
					quarterNumber = new CadastralNumber(reader.ReadElementContentAsString());
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8064))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8092))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0099(reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8136))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u009a(reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8198))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u009b(reader);
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassd9
	{
		public Cadastre <>4__this;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassd9()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadCadastralBlocksNode>b__d8()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8242))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u009c(reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassdc
	{
		public Cadastre <>4__this;

		public XmlTextReader reader;

		public string recordNodeName;

		public ConstructionType constructionType;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassdc()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadPropertyBuildNode>b__db()
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(156))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8276))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(reader);
				}
				else if (reader.LocalName == recordNodeName)
				{
					Construction construction = new Construction
					{
						ConstructionType = constructionType
					};
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009a(construction, reader);
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0094.Add(construction);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8310))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0087(reader);
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassdf
	{
		public Cadastre <>4__this;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassdf()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadBaseParamsLandNode>b__de()
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(160))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8340))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8374))
				{
					Parcel parcel = new Parcel();
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(parcel, reader);
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0091.Add(parcel);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8400))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0087(reader);
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClasse2
	{
		public Cadastre <>4__this;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClasse2()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadCadastralPlanTerritoryNode>b__e1()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8430))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(reader);
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8464))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u009d(reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClasse5
	{
		public Cadastre <>4__this;

		public Restriction restriction;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClasse5()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadEncumbrance>b__e4()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8500))
			{
				restriction.Type.Code = reader.ReadContentAsString();
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8512))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassf2
	{
		public Cadastre <>4__this;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassf2()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadRightRecordsNode>b__f1()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8524))
			{
				RightRecord rightRecord = new RightRecord();
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0088(rightRecord, reader);
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0095.Add(rightRecord);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassf5
	{
		public Cadastre <>4__this;

		public RightRecord rightRecord;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassf5()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadRightRecordNode>b__f4()
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(164))
			{
				if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8552))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0089(rightRecord, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8578))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0089(rightRecord, reader);
				}
				else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8602))
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008a(rightRecord, reader);
				}
				else
				{
					<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
				}
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassf8
	{
		public Cadastre <>4__this;

		public RightRecord rightRecord;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassf8()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadRightDataNode>b__f7()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8632))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0094(rightRecord.RightType, reader);
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8656))
			{
				rightRecord.RightNumber = reader.ReadElementContentAsString();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassfb
	{
		public Cadastre <>4__this;

		public RightRecord rightRecord;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassfb()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadRightHoldersNode>b__fa()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8684))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008b(rightRecord, reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClassfe
	{
		public Cadastre <>4__this;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClassfe()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadRightHolderNode>b__fd()
		{
			RightHolder rightHolder = new RightHolder();
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8712))
			{
				rightHolder.Individual = false;
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008d(rightHolder, reader);
			}
			else if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8748))
			{
				rightHolder.Individual = true;
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008c(rightHolder, reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass101
	{
		public Cadastre <>4__this;

		public RightHolder rightHolder;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass101()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadIndividualNode>b__100()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8772))
			{
				rightHolder.Name = reader.ReadElementContentAsString();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass104
	{
		public Cadastre <>4__this;

		public RightHolder rightHolder;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass104()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadPublicFormationNode>b__103()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8784))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008e(rightHolder, reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass107
	{
		public Cadastre <>4__this;

		public RightHolder rightHolder;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass107()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadPublicFormationTypeNode>b__106()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8830))
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008f(rightHolder, reader);
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass10a
	{
		public Cadastre <>4__this;

		public RightHolder rightHolder;

		public XmlTextReader reader;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public <>c__DisplayClass10a()
		{
			global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
			base..ctor();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void <ReadMunicipalityNode>b__109()
		{
			if (reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8858))
			{
				rightHolder.Name = reader.ReadElementContentAsString();
			}
			else
			{
				<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(reader);
			}
		}
	}

	private string \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0090;

	private List<Parcel> \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0091;

	private List<EntitySpatial> \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0092;

	private Dictionary<string, Bound> \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0093;

	private List<Construction> \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0094;

	private List<RightRecord> \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0095;

	private object \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0096;

	public string RequestDate
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0090;
		}
	}

	public IEnumerable<RightRecord> RightRecords
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0095;
		}
	}

	public string[] Districts
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			HashSet<string> hashSet = new HashSet<string>();
			List<CadastralObject> list = new List<CadastralObject>();
			list.AddRange(\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0091.ToArray());
			list.AddRange(\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0094.ToArray());
			foreach (CadastralObject item in list)
			{
				string district = item.CadastralNumber.District;
				if (!string.IsNullOrEmpty(district) && !hashSet.Contains(district))
				{
					hashSet.Add(district);
				}
			}
			return hashSet.ToArray();
		}
	}

	public IList<Parcel> Parcels
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0091;
		}
	}

	public IList<EntitySpatial> SpatialData
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0092;
		}
	}

	public IList<Bound> Bounds
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0093.Values.ToList();
		}
	}

	public IList<Construction> ObjectsRealty
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0094;
		}
	}

	public object Owner
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0096;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw new NotSupportedException();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Cadastre(object owner)
	{
		global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a.\u009e\u009e\u009e\u009e\u0086\u0089();
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0090 = string.Empty;
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0091 = new List<Parcel>();
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0092 = new List<EntitySpatial>();
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0093 = new Dictionary<string, Bound>();
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0094 = new List<Construction>();
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0095 = new List<RightRecord>();
		base..ctor();
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0096 = owner;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Parcel GetParcel(CadastralNumber cadastralNumber)
	{
		foreach (Parcel item in \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0091)
		{
			if (item.CadastralNumber.Equals(cadastralNumber))
			{
				return item;
			}
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Construction GetConstruction(CadastralNumber cadastralNumber)
	{
		foreach (Construction item in \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0094)
		{
			if (item.CadastralNumber.Equals(cadastralNumber))
			{
				return item;
			}
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public CadastralObject GetCadastralObject(CadastralNumber cadastralNumber)
	{
		CadastralObject cadastralObject = GetParcel(cadastralNumber);
		if (cadastralObject == null)
		{
			cadastralObject = GetConstruction(cadastralNumber);
		}
		return cadastralObject;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool Contains(CadastralObject cadastralObject)
	{
		if (cadastralObject is Parcel)
		{
			return \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0091.Contains((Parcel)cadastralObject);
		}
		if (cadastralObject is Construction)
		{
			return \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0094.Contains((Construction)cadastralObject);
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Bound GetBound(string regNumber)
	{
		if (\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0093.ContainsKey(regNumber))
		{
			return \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0093[regNumber];
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string[] GetAreasForDistrict(string district)
	{
		HashSet<string> hashSet = new HashSet<string>();
		List<CadastralObject> list = new List<CadastralObject>();
		list.AddRange(\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0091.ToArray());
		list.AddRange(\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0094.ToArray());
		foreach (CadastralObject item in list)
		{
			CadastralNumber cadastralNumber = item.CadastralNumber;
			if (cadastralNumber.District.Equals(district, StringComparison.InvariantCultureIgnoreCase))
			{
				string area = cadastralNumber.Area;
				if (!string.IsNullOrEmpty(area) && !hashSet.Contains(area))
				{
					hashSet.Add(area);
				}
			}
		}
		return hashSet.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public string[] GetQuartersForArea(string district, string area)
	{
		HashSet<string> hashSet = new HashSet<string>();
		List<CadastralObject> list = new List<CadastralObject>();
		list.AddRange(\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0091.ToArray());
		list.AddRange(\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0094.ToArray());
		foreach (CadastralObject item in list)
		{
			CadastralNumber cadastralNumber = item.CadastralNumber;
			if (cadastralNumber.District.Equals(district, StringComparison.InvariantCultureIgnoreCase) && cadastralNumber.Area.Equals(area, StringComparison.InvariantCultureIgnoreCase))
			{
				string quarter = cadastralNumber.Quarter;
				if (!string.IsNullOrEmpty(quarter) && !hashSet.Contains(quarter))
				{
					hashSet.Add(quarter);
				}
			}
		}
		return hashSet.ToArray();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Parcel GetParcel(string district, string area, string quarter, string number)
	{
		new List<Parcel>();
		foreach (Parcel item in \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0091)
		{
			CadastralNumber cadastralNumber = item.CadastralNumber;
			if (cadastralNumber.District.Equals(district, StringComparison.InvariantCultureIgnoreCase) && cadastralNumber.Area.Equals(area, StringComparison.InvariantCultureIgnoreCase) && cadastralNumber.Quarter.Equals(quarter, StringComparison.InvariantCultureIgnoreCase) && cadastralNumber.Number.Equals(number, StringComparison.InvariantCultureIgnoreCase))
			{
				return item;
			}
		}
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void LoadFromFile(string fullpath)
	{
		if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(8))
		{
			return;
		}
		using XmlTextReader xmlTextReader = new XmlTextReader(fullpath);
		xmlTextReader.WhitespaceHandling = WhitespaceHandling.None;
		if (!xmlTextReader.Read())
		{
			return;
		}
		xmlTextReader.MoveToContent();
		if (xmlTextReader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(62) || xmlTextReader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(114))
		{
			\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0086(xmlTextReader);
			return;
		}
		if (xmlTextReader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(172))
		{
			\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0087(xmlTextReader);
			return;
		}
		if (xmlTextReader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(240))
		{
			\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u009e(xmlTextReader, global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(300), ConstructionType.Building);
			return;
		}
		if (xmlTextReader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(328))
		{
			\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u009e(xmlTextReader, global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(402), ConstructionType.Construction);
			return;
		}
		if (xmlTextReader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(444))
		{
			\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u009e(xmlTextReader, global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(530), ConstructionType.Uncompleted);
		}
		if ((xmlTextReader.LocalName != global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(598) && xmlTextReader.LocalName != global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(610) && xmlTextReader.LocalName != global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(620)) || !xmlTextReader.Read())
		{
			return;
		}
		int depth = xmlTextReader.Depth;
		while (xmlTextReader.Depth >= depth)
		{
			if (xmlTextReader.NodeType == XmlNodeType.Element)
			{
				if (xmlTextReader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(632))
				{
					Parcel parcel = new Parcel();
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0090(parcel, xmlTextReader);
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0091.Add(parcel);
					if (xmlTextReader.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(xmlTextReader);
					}
				}
				if (xmlTextReader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(648))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008b(xmlTextReader);
					if (xmlTextReader.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(xmlTextReader);
					}
				}
				else if (xmlTextReader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(666))
				{
					if (!xmlTextReader.Read())
					{
						continue;
					}
					int depth2 = xmlTextReader.Depth;
					while (xmlTextReader.Depth >= depth2)
					{
						if (xmlTextReader.NodeType == XmlNodeType.Element)
						{
							if (xmlTextReader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(700))
							{
								\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0089(xmlTextReader);
								if (xmlTextReader.NodeType == XmlNodeType.EndElement)
								{
									\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(xmlTextReader);
								}
							}
							else
							{
								\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(xmlTextReader);
							}
						}
						else
						{
							\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(xmlTextReader);
						}
					}
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(xmlTextReader);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(xmlTextReader);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(XmlTextReader P_0)
	{
		<>c__DisplayClass1 CS$<>8__locals8 = new <>c__DisplayClass1();
		CS$<>8__locals8.reader = P_0;
		CS$<>8__locals8.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals8.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3422))
			{
				CS$<>8__locals8.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0090 = CS$<>8__locals8.reader.ReadElementContentAsString();
			}
			else
			{
				CS$<>8__locals8.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals8.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals8.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(Parcel P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass4 CS$<>8__locals42 = new <>c__DisplayClass4();
		CS$<>8__locals42.parcel = P_0;
		CS$<>8__locals42.reader = P_1;
		CS$<>8__locals42.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(80))
			{
				if (CS$<>8__locals42.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3468))
				{
					CS$<>8__locals42.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0089(CS$<>8__locals42.parcel, CS$<>8__locals42.reader);
				}
				else if (CS$<>8__locals42.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3494))
				{
					CS$<>8__locals42.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009c(CS$<>8__locals42.parcel, CS$<>8__locals42.reader);
				}
				else if (CS$<>8__locals42.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3516))
				{
					CS$<>8__locals42.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008b(CS$<>8__locals42.parcel, CS$<>8__locals42.reader);
				}
				else if (CS$<>8__locals42.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3532))
				{
					CS$<>8__locals42.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008e(CS$<>8__locals42.parcel, CS$<>8__locals42.reader);
				}
				else if (CS$<>8__locals42.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3548))
				{
					CS$<>8__locals42.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0087(CS$<>8__locals42.parcel, CS$<>8__locals42.reader);
				}
				else if (CS$<>8__locals42.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3584))
				{
					CS$<>8__locals42.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0099(CS$<>8__locals42.parcel, CS$<>8__locals42.reader);
				}
				else if (CS$<>8__locals42.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3612))
				{
					CS$<>8__locals42.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0092(CS$<>8__locals42.parcel, CS$<>8__locals42.reader);
				}
				else if (CS$<>8__locals42.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3650))
				{
					CS$<>8__locals42.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0098(CS$<>8__locals42.parcel, CS$<>8__locals42.reader);
				}
				else if (CS$<>8__locals42.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3704))
				{
					CS$<>8__locals42.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008d(CS$<>8__locals42.parcel, CS$<>8__locals42.reader);
				}
				else
				{
					CS$<>8__locals42.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals42.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals42.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0089(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008b.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008a P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass7 CS$<>8__locals9 = new <>c__DisplayClass7();
		CS$<>8__locals9.cadastralObject = P_0;
		CS$<>8__locals9.reader = P_1;
		CS$<>8__locals9.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals9.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3716))
			{
				CS$<>8__locals9.cadastralObject.RegistrationDate = CS$<>8__locals9.reader.ReadElementContentAsString();
			}
			else
			{
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals9.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals9.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008a(CadastralObject P_0, XmlTextReader P_1)
	{
		<>c__DisplayClassa CS$<>8__locals15 = new <>c__DisplayClassa();
		CS$<>8__locals15.obj = P_0;
		CS$<>8__locals15.reader = P_1;
		CS$<>8__locals15.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals15.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3754))
			{
				CS$<>8__locals15.obj.CadastralNumber = new CadastralNumber(CS$<>8__locals15.reader.ReadElementContentAsString());
			}
			else if (CS$<>8__locals15.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3778))
			{
				CS$<>8__locals15.obj.QuarterNumber = new CadastralNumber(CS$<>8__locals15.reader.ReadElementContentAsString());
			}
			else if (CS$<>8__locals15.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3818))
			{
				CS$<>8__locals15.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals15.reader);
			}
			else
			{
				CS$<>8__locals15.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals15.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals15.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008b(CadastralObject P_0, XmlTextReader P_1)
	{
		<>c__DisplayClassd CS$<>8__locals13 = new <>c__DisplayClassd();
		CS$<>8__locals13.obj = P_0;
		CS$<>8__locals13.reader = P_1;
		CS$<>8__locals13.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3830))
			{
				CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008a(CS$<>8__locals13.obj, CS$<>8__locals13.reader);
			}
			else if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3856))
			{
				CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals13.reader);
			}
			else
			{
				CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals13.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals13.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008c(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0089.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088 P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass10 CS$<>8__locals12 = new <>c__DisplayClass10();
		CS$<>8__locals12.obj = P_0;
		CS$<>8__locals12.reader = P_1;
		CS$<>8__locals12.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals12.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3874))
			{
				CS$<>8__locals12.obj.Area = CS$<>8__locals12.reader.ReadElementContentAsString();
			}
			else if (CS$<>8__locals12.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3888))
			{
				CS$<>8__locals12.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals12.reader);
			}
			else
			{
				CS$<>8__locals12.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals12.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals12.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008d(CadastralObject P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass13 CS$<>8__locals9 = new <>c__DisplayClass13();
		CS$<>8__locals9.obj = P_0;
		CS$<>8__locals9.reader = P_1;
		CS$<>8__locals9.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals9.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3900))
			{
				CS$<>8__locals9.obj.Cost = CS$<>8__locals9.reader.ReadElementContentAsDouble();
			}
			else
			{
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals9.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals9.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008e(Parcel P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass16 CS$<>8__locals18 = new <>c__DisplayClass16();
		CS$<>8__locals18.parcel = P_0;
		CS$<>8__locals18.reader = P_1;
		CS$<>8__locals18.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(84))
			{
				if (CS$<>8__locals18.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3914))
				{
					CS$<>8__locals18.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008c(CS$<>8__locals18.parcel, CS$<>8__locals18.reader);
				}
				else if (CS$<>8__locals18.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3926))
				{
					CS$<>8__locals18.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008f(CS$<>8__locals18.parcel, CS$<>8__locals18.reader);
				}
				else if (CS$<>8__locals18.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3946))
				{
					CS$<>8__locals18.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0090(CS$<>8__locals18.parcel, CS$<>8__locals18.reader);
				}
				else
				{
					CS$<>8__locals18.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals18.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals18.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008f(Parcel P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass19 CS$<>8__locals10 = new <>c__DisplayClass19();
		CS$<>8__locals10.parcel = P_0;
		CS$<>8__locals10.reader = P_1;
		CS$<>8__locals10.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals10.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3976))
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0094(CS$<>8__locals10.parcel.Category, CS$<>8__locals10.reader);
			}
			else
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals10.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals10.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0090(Parcel P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass1c CS$<>8__locals10 = new <>c__DisplayClass1c();
		CS$<>8__locals10.parcel = P_0;
		CS$<>8__locals10.reader = P_1;
		CS$<>8__locals10.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals10.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3988))
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0091(CS$<>8__locals10.parcel, CS$<>8__locals10.reader);
			}
			else
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals10.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals10.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0091(Parcel P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass1f CS$<>8__locals9 = new <>c__DisplayClass1f();
		CS$<>8__locals9.parcel = P_0;
		CS$<>8__locals9.reader = P_1;
		CS$<>8__locals9.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals9.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4042))
			{
				CS$<>8__locals9.parcel.PermittedUses.Add(CS$<>8__locals9.reader.ReadElementContentAsString());
			}
			else
			{
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals9.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals9.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092(Construction P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass22 CS$<>8__locals29 = new <>c__DisplayClass22();
		CS$<>8__locals29.construction = P_0;
		CS$<>8__locals29.reader = P_1;
		CS$<>8__locals29.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(88))
			{
				if (CS$<>8__locals29.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4068))
				{
					CS$<>8__locals29.construction.Area = CS$<>8__locals29.reader.ReadElementContentAsString();
				}
				else if (CS$<>8__locals29.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4080))
				{
					CS$<>8__locals29.construction.Floors = (byte)CS$<>8__locals29.reader.ReadElementContentAsInt();
				}
				else if (CS$<>8__locals29.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4096))
				{
					string s = CS$<>8__locals29.reader.ReadElementContentAsString();
					if (byte.TryParse(s, out var result))
					{
						CS$<>8__locals29.construction.UndergroundFloors = result;
					}
				}
				else if (CS$<>8__locals29.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4136))
				{
					CS$<>8__locals29.construction.YearBuilt = (ushort)CS$<>8__locals29.reader.ReadElementContentAsInt();
				}
				else if (CS$<>8__locals29.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4160))
				{
					CS$<>8__locals29.construction.YearCommisioning = (ushort)CS$<>8__locals29.reader.ReadElementContentAsInt();
				}
				else if (CS$<>8__locals29.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4198))
				{
					CS$<>8__locals29.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0094(CS$<>8__locals29.construction.Purpose, CS$<>8__locals29.reader);
				}
				else if (CS$<>8__locals29.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4216))
				{
					CS$<>8__locals29.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093(CS$<>8__locals29.construction, CS$<>8__locals29.reader);
				}
				else
				{
					CS$<>8__locals29.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals29.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals29.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093(Construction P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass25 CS$<>8__locals10 = new <>c__DisplayClass25();
		CS$<>8__locals10.construction = P_0;
		CS$<>8__locals10.reader = P_1;
		CS$<>8__locals10.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals10.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4248))
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0094(CS$<>8__locals10.construction, CS$<>8__locals10.reader);
			}
			else
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals10.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals10.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0094(Construction P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass28 CS$<>8__locals9 = new <>c__DisplayClass28();
		CS$<>8__locals9.construction = P_0;
		CS$<>8__locals9.reader = P_1;
		CS$<>8__locals9.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals9.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4278))
			{
				CS$<>8__locals9.construction.PermittedUses.Add(CS$<>8__locals9.reader.ReadElementContentAsString());
			}
			else
			{
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals9.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals9.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0095(Address P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass2b CS$<>8__locals12 = new <>c__DisplayClass2b();
		CS$<>8__locals12.address = P_0;
		CS$<>8__locals12.reader = P_1;
		CS$<>8__locals12.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals12.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4290))
			{
				CS$<>8__locals12.address.Region = CS$<>8__locals12.reader.ReadElementContentAsString();
			}
			else if (CS$<>8__locals12.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4304))
			{
				CS$<>8__locals12.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals12.reader);
			}
			else
			{
				CS$<>8__locals12.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals12.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals12.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0096(Address P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass2e CS$<>8__locals13 = new <>c__DisplayClass2e();
		CS$<>8__locals13.address = P_0;
		CS$<>8__locals13.reader = P_1;
		CS$<>8__locals13.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			CS$<>8__locals13.address.District = new Address.TypedString();
			if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4316))
			{
				CS$<>8__locals13.address.District.Value = CS$<>8__locals13.reader.ReadElementContentAsString();
			}
			else if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4346))
			{
				CS$<>8__locals13.address.District.Type = CS$<>8__locals13.reader.ReadElementContentAsString();
			}
			else
			{
				CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals13.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals13.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0097(Address P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass31 CS$<>8__locals13 = new <>c__DisplayClass31();
		CS$<>8__locals13.address = P_0;
		CS$<>8__locals13.reader = P_1;
		CS$<>8__locals13.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			CS$<>8__locals13.address.City = new Address.TypedString();
			if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4376))
			{
				CS$<>8__locals13.address.City.Value = CS$<>8__locals13.reader.ReadElementContentAsString();
			}
			else if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4398))
			{
				CS$<>8__locals13.address.City.Type = CS$<>8__locals13.reader.ReadElementContentAsString();
			}
			else
			{
				CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals13.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals13.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0098(Address P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass34 CS$<>8__locals13 = new <>c__DisplayClass34();
		CS$<>8__locals13.address = P_0;
		CS$<>8__locals13.reader = P_1;
		CS$<>8__locals13.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			CS$<>8__locals13.address.Street = new Address.TypedString();
			if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4420))
			{
				CS$<>8__locals13.address.Street.Value = CS$<>8__locals13.reader.ReadElementContentAsString();
			}
			else if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4446))
			{
				CS$<>8__locals13.address.Street.Type = CS$<>8__locals13.reader.ReadElementContentAsString();
			}
			else
			{
				CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals13.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals13.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0099(Address P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass37 CS$<>8__locals13 = new <>c__DisplayClass37();
		CS$<>8__locals13.address = P_0;
		CS$<>8__locals13.reader = P_1;
		CS$<>8__locals13.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			CS$<>8__locals13.address.Level1 = new Address.TypedString();
			if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4472))
			{
				CS$<>8__locals13.address.Level1.Value = CS$<>8__locals13.reader.ReadElementContentAsString();
			}
			else if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4498))
			{
				CS$<>8__locals13.address.Level1.Type = CS$<>8__locals13.reader.ReadElementContentAsString();
			}
			else
			{
				CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals13.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals13.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a(Address P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass3a CS$<>8__locals13 = new <>c__DisplayClass3a();
		CS$<>8__locals13.address = P_0;
		CS$<>8__locals13.reader = P_1;
		CS$<>8__locals13.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			CS$<>8__locals13.address.Level2 = new Address.TypedString();
			if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4524))
			{
				CS$<>8__locals13.address.Level2.Value = CS$<>8__locals13.reader.ReadElementContentAsString();
			}
			else if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4550))
			{
				CS$<>8__locals13.address.Level2.Type = CS$<>8__locals13.reader.ReadElementContentAsString();
			}
			else
			{
				CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals13.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals13.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b(Address P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass3d CS$<>8__locals13 = new <>c__DisplayClass3d();
		CS$<>8__locals13.address = P_0;
		CS$<>8__locals13.reader = P_1;
		CS$<>8__locals13.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			CS$<>8__locals13.address.Apartment = new Address.TypedString();
			if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4576))
			{
				CS$<>8__locals13.address.Apartment.Value = CS$<>8__locals13.reader.ReadElementContentAsString();
			}
			else if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4608))
			{
				CS$<>8__locals13.address.Apartment.Type = CS$<>8__locals13.reader.ReadElementContentAsString();
			}
			else
			{
				CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals13.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals13.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009c(Address P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass40 CS$<>8__locals24 = new <>c__DisplayClass40();
		CS$<>8__locals24.address = P_0;
		CS$<>8__locals24.reader = P_1;
		CS$<>8__locals24.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(92))
			{
				if (CS$<>8__locals24.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4640))
				{
					CS$<>8__locals24.address.OKATO = CS$<>8__locals24.reader.ReadElementContentAsString();
				}
				else if (CS$<>8__locals24.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4654))
				{
					CS$<>8__locals24.address.KLADR = CS$<>8__locals24.reader.ReadElementContentAsString();
				}
				else if (CS$<>8__locals24.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4668))
				{
					CS$<>8__locals24.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0095(CS$<>8__locals24.address, CS$<>8__locals24.reader);
				}
				else if (CS$<>8__locals24.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4684))
				{
					CS$<>8__locals24.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0096(CS$<>8__locals24.address, CS$<>8__locals24.reader);
				}
				else if (CS$<>8__locals24.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4704))
				{
					CS$<>8__locals24.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0097(CS$<>8__locals24.address, CS$<>8__locals24.reader);
				}
				else
				{
					CS$<>8__locals24.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals24.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals24.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009d(Address P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass43 CS$<>8__locals22 = new <>c__DisplayClass43();
		CS$<>8__locals22.address = P_0;
		CS$<>8__locals22.reader = P_1;
		CS$<>8__locals22.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(96))
			{
				if (CS$<>8__locals22.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4716))
				{
					CS$<>8__locals22.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0098(CS$<>8__locals22.address, CS$<>8__locals22.reader);
				}
				else if (CS$<>8__locals22.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4732))
				{
					CS$<>8__locals22.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0099(CS$<>8__locals22.address, CS$<>8__locals22.reader);
				}
				else if (CS$<>8__locals22.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4748))
				{
					CS$<>8__locals22.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009a(CS$<>8__locals22.address, CS$<>8__locals22.reader);
				}
				else if (CS$<>8__locals22.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4764))
				{
					CS$<>8__locals22.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009b(CS$<>8__locals22.address, CS$<>8__locals22.reader);
				}
				else
				{
					CS$<>8__locals22.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals22.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals22.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009e(Address P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass46 CS$<>8__locals14 = new <>c__DisplayClass46();
		CS$<>8__locals14.address = P_0;
		CS$<>8__locals14.reader = P_1;
		CS$<>8__locals14.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals14.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4786))
			{
				CS$<>8__locals14.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009c(CS$<>8__locals14.address, CS$<>8__locals14.reader);
			}
			else if (CS$<>8__locals14.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4822))
			{
				CS$<>8__locals14.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009d(CS$<>8__locals14.address, CS$<>8__locals14.reader);
			}
			else
			{
				CS$<>8__locals14.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals14.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals14.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0086(Address P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass49 CS$<>8__locals13 = new <>c__DisplayClass49();
		CS$<>8__locals13.address = P_0;
		CS$<>8__locals13.reader = P_1;
		CS$<>8__locals13.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4854))
			{
				CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u009e(CS$<>8__locals13.address, CS$<>8__locals13.reader);
			}
			else if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4882))
			{
				CS$<>8__locals13.address.ReadableAddress = CS$<>8__locals13.reader.ReadElementContentAsString();
			}
			else
			{
				CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals13.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals13.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0087(object P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass4c CS$<>8__locals15 = new <>c__DisplayClass4c();
		CS$<>8__locals15.obj = P_0;
		CS$<>8__locals15.reader = P_1;
		CS$<>8__locals15.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(100))
			{
				if (CS$<>8__locals15.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4918))
				{
					if (CS$<>8__locals15.obj is Parcel)
					{
						Address address = new Address();
						CS$<>8__locals15.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0086(address, CS$<>8__locals15.reader);
						((Parcel)CS$<>8__locals15.obj).Addresses.Add(address);
					}
					else if (CS$<>8__locals15.obj is Construction)
					{
						Construction construction = (Construction)CS$<>8__locals15.obj;
						_ = construction.Address;
						CS$<>8__locals15.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0086(construction.Address, CS$<>8__locals15.reader);
					}
				}
				else
				{
					CS$<>8__locals15.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals15.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals15.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0088(SpelementUnit P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass4f CS$<>8__locals21 = new <>c__DisplayClass4f();
		CS$<>8__locals21.spelementUnit = P_0;
		CS$<>8__locals21.reader = P_1;
		CS$<>8__locals21.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(104))
			{
				if (CS$<>8__locals21.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4936))
				{
					CS$<>8__locals21.spelementUnit.X = CS$<>8__locals21.reader.ReadElementContentAsDouble();
				}
				else if (CS$<>8__locals21.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4942))
				{
					CS$<>8__locals21.spelementUnit.Y = CS$<>8__locals21.reader.ReadElementContentAsDouble();
				}
				else if (CS$<>8__locals21.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4948))
				{
					CS$<>8__locals21.spelementUnit.Number = CS$<>8__locals21.reader.ReadElementContentAsInt();
				}
				else if (CS$<>8__locals21.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4966))
				{
					CS$<>8__locals21.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals21.reader);
				}
				else if (CS$<>8__locals21.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(4994))
				{
					CS$<>8__locals21.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals21.reader);
				}
				else
				{
					CS$<>8__locals21.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals21.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals21.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0089(SpatialElement P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass52 CS$<>8__locals10 = new <>c__DisplayClass52();
		CS$<>8__locals10.spatialElement = P_0;
		CS$<>8__locals10.reader = P_1;
		CS$<>8__locals10.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals10.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5026))
			{
				SpelementUnit spelementUnit = new SpelementUnit();
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0088(spelementUnit, CS$<>8__locals10.reader);
				CS$<>8__locals10.spatialElement.Add(spelementUnit);
			}
			else
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals10.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals10.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008a(SpatialElement P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass55 CS$<>8__locals10 = new <>c__DisplayClass55();
		CS$<>8__locals10.spatialElement = P_0;
		CS$<>8__locals10.reader = P_1;
		CS$<>8__locals10.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals10.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5046))
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0089(CS$<>8__locals10.spatialElement, CS$<>8__locals10.reader);
			}
			else
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals10.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals10.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008b(EntitySpatial P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass58 CS$<>8__locals11 = new <>c__DisplayClass58();
		CS$<>8__locals11.entitySpatial = P_0;
		CS$<>8__locals11.reader = P_1;
		CS$<>8__locals11.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals11.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5068))
			{
				SpatialElement spatialElement = new SpatialElement(CS$<>8__locals11.entitySpatial);
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008a(spatialElement, CS$<>8__locals11.reader);
				CS$<>8__locals11.entitySpatial.Elements.Add(spatialElement);
			}
			else
			{
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals11.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals11.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008c(EntitySpatial P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass5b CS$<>8__locals14 = new <>c__DisplayClass5b();
		CS$<>8__locals14.entitySpatial = P_0;
		CS$<>8__locals14.reader = P_1;
		CS$<>8__locals14.<>4__this = this;
		CS$<>8__locals14.entitySpatial.Elements.ToList();
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals14.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5102))
			{
				CS$<>8__locals14.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008b(CS$<>8__locals14.entitySpatial, CS$<>8__locals14.reader);
			}
			else if (CS$<>8__locals14.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5140))
			{
				CS$<>8__locals14.entitySpatial.Sk_Id = CS$<>8__locals14.reader.ReadElementContentAsString();
			}
			else
			{
				CS$<>8__locals14.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals14.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals14.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008d(Boundary P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass5e CS$<>8__locals11 = new <>c__DisplayClass5e();
		CS$<>8__locals11.boundary = P_0;
		CS$<>8__locals11.reader = P_1;
		CS$<>8__locals11.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals11.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5154))
			{
				EntitySpatial entitySpatial = new EntitySpatial(CS$<>8__locals11.boundary);
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008c(entitySpatial, CS$<>8__locals11.reader);
				CS$<>8__locals11.boundary.Add(entitySpatial);
			}
			else
			{
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals11.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals11.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008e(EntitySpatial P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass61 CS$<>8__locals13 = new <>c__DisplayClass61();
		CS$<>8__locals13.spatial = P_0;
		CS$<>8__locals13.reader = P_1;
		CS$<>8__locals13.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(108))
			{
				if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5186))
				{
					CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008c(CS$<>8__locals13.spatial, CS$<>8__locals13.reader);
					Borders borders = new Borders();
					foreach (SpatialElement element in CS$<>8__locals13.spatial.Elements)
					{
						for (int i = 0; i < element.Count - 1; i++)
						{
							borders.Add(new Border
							{
								Spatial = CS$<>8__locals13.spatial.Elements.Count - 1,
								Point1 = element[i].Number,
								Point2 = element[i + 1].Number
							});
						}
					}
					CS$<>8__locals13.spatial.Borders.Add(borders);
				}
				else
				{
					CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals13.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals13.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008f(EntitySpatial P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass64 CS$<>8__locals10 = new <>c__DisplayClass64();
		CS$<>8__locals10.spatial = P_0;
		CS$<>8__locals10.reader = P_1;
		CS$<>8__locals10.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals10.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5218))
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008e(CS$<>8__locals10.spatial, CS$<>8__locals10.reader);
			}
			else
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals10.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals10.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0090(Bound P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass67 CS$<>8__locals11 = new <>c__DisplayClass67();
		CS$<>8__locals11.bound = P_0;
		CS$<>8__locals11.reader = P_1;
		CS$<>8__locals11.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals11.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5236))
			{
				Boundary boundary = new Boundary(CS$<>8__locals11.bound);
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008d(boundary, CS$<>8__locals11.reader);
				CS$<>8__locals11.bound.Boundaries.Add(boundary);
			}
			else
			{
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals11.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals11.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0091(LandPlotPart P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass6a CS$<>8__locals26 = new <>c__DisplayClass6a();
		CS$<>8__locals26.subParcel = P_0;
		CS$<>8__locals26.reader = P_1;
		CS$<>8__locals26.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(112))
			{
				if (CS$<>8__locals26.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5254))
				{
					CS$<>8__locals26.subParcel.Date = CS$<>8__locals26.reader.ReadElementContentAsString();
				}
				else if (CS$<>8__locals26.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5278))
				{
					CS$<>8__locals26.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008f(CS$<>8__locals26.subParcel.Spatial, CS$<>8__locals26.reader);
				}
				else if (CS$<>8__locals26.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5298))
				{
					CS$<>8__locals26.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008c(CS$<>8__locals26.subParcel, CS$<>8__locals26.reader);
				}
				else if (CS$<>8__locals26.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5310))
				{
					CS$<>8__locals26.subParcel.Number = CS$<>8__locals26.reader.ReadElementContentAsString();
				}
				else if (CS$<>8__locals26.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5336))
				{
					CS$<>8__locals26.subParcel.Mnemonic = CS$<>8__locals26.reader.ReadElementContentAsString();
				}
				else if (CS$<>8__locals26.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5356))
				{
					CS$<>8__locals26.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals26.reader);
				}
				else
				{
					CS$<>8__locals26.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals26.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals26.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0092(Parcel P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass6d CS$<>8__locals10 = new <>c__DisplayClass6d();
		CS$<>8__locals10.parcel = P_0;
		CS$<>8__locals10.reader = P_1;
		CS$<>8__locals10.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals10.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5400))
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008f(CS$<>8__locals10.parcel.Spatial, CS$<>8__locals10.reader);
			}
			else
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals10.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals10.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0093(Bound P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass70 CS$<>8__locals10 = new <>c__DisplayClass70();
		CS$<>8__locals10.bound = P_0;
		CS$<>8__locals10.reader = P_1;
		CS$<>8__locals10.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals10.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5420))
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0090(CS$<>8__locals10.bound, CS$<>8__locals10.reader);
			}
			else
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals10.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals10.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0094(CadastralType P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass73 CS$<>8__locals9 = new <>c__DisplayClass73();
		CS$<>8__locals9.type = P_0;
		CS$<>8__locals9.reader = P_1;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals9.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5440))
			{
				CS$<>8__locals9.type.Code = CS$<>8__locals9.reader.ReadElementContentAsString();
			}
			else if (CS$<>8__locals9.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5452))
			{
				CS$<>8__locals9.type.Value = CS$<>8__locals9.reader.ReadElementContentAsString();
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals9.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0095(Restriction P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass76 CS$<>8__locals20 = new <>c__DisplayClass76();
		CS$<>8__locals20.restriction = P_0;
		CS$<>8__locals20.reader = P_1;
		CS$<>8__locals20.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(116))
			{
				if (CS$<>8__locals20.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5466))
				{
					CS$<>8__locals20.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0094(CS$<>8__locals20.restriction.Type, CS$<>8__locals20.reader);
				}
				else if (CS$<>8__locals20.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5502))
				{
					CS$<>8__locals20.restriction.PartNumber = CS$<>8__locals20.reader.ReadElementContentAsString();
				}
				else if (CS$<>8__locals20.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5528))
				{
					CS$<>8__locals20.restriction.Content = CS$<>8__locals20.reader.ReadElementContentAsString();
				}
				else if (CS$<>8__locals20.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5590))
				{
					CS$<>8__locals20.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0096(CS$<>8__locals20.restriction, CS$<>8__locals20.reader);
				}
				else
				{
					CS$<>8__locals20.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals20.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals20.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0096(Restriction P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass79 CS$<>8__locals10 = new <>c__DisplayClass79();
		CS$<>8__locals10.restriction = P_0;
		CS$<>8__locals10.reader = P_1;
		CS$<>8__locals10.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals10.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5610))
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0097(CS$<>8__locals10.restriction, CS$<>8__locals10.reader);
			}
			else
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals10.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals10.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0097(Restriction P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass7c CS$<>8__locals9 = new <>c__DisplayClass7c();
		CS$<>8__locals9.restriction = P_0;
		CS$<>8__locals9.reader = P_1;
		CS$<>8__locals9.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals9.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5648))
			{
				CS$<>8__locals9.restriction.RegNumberBorder = CS$<>8__locals9.reader.ReadElementContentAsString();
			}
			else
			{
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals9.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals9.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0098(Parcel P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass7f CS$<>8__locals10 = new <>c__DisplayClass7f();
		CS$<>8__locals10.parcel = P_0;
		CS$<>8__locals10.reader = P_1;
		CS$<>8__locals10.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals10.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5664))
			{
				Restriction restriction = new Restriction();
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0095(restriction, CS$<>8__locals10.reader);
				CS$<>8__locals10.parcel.Restrictions.Add(restriction);
			}
			else
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals10.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals10.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0099(Parcel P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass82 CS$<>8__locals11 = new <>c__DisplayClass82();
		CS$<>8__locals11.parcel = P_0;
		CS$<>8__locals11.reader = P_1;
		CS$<>8__locals11.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals11.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5714))
			{
				LandPlotPart landPlotPart = new LandPlotPart(CS$<>8__locals11.parcel);
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0091(landPlotPart, CS$<>8__locals11.reader);
				CS$<>8__locals11.parcel.AddSubParcel(landPlotPart);
			}
			else
			{
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals11.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals11.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009a(Construction P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass85 CS$<>8__locals34 = new <>c__DisplayClass85();
		CS$<>8__locals34.construction = P_0;
		CS$<>8__locals34.reader = P_1;
		CS$<>8__locals34.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(120))
			{
				if (CS$<>8__locals34.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5740))
				{
					CS$<>8__locals34.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0089(CS$<>8__locals34.construction, CS$<>8__locals34.reader);
				}
				else if (CS$<>8__locals34.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5766))
				{
					CS$<>8__locals34.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008b(CS$<>8__locals34.construction, CS$<>8__locals34.reader);
				}
				else if (CS$<>8__locals34.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5782))
				{
					CS$<>8__locals34.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009b(CS$<>8__locals34.construction, CS$<>8__locals34.reader);
				}
				else if (CS$<>8__locals34.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5804))
				{
					CS$<>8__locals34.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092(CS$<>8__locals34.construction, CS$<>8__locals34.reader);
				}
				else if (CS$<>8__locals34.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5820))
				{
					CS$<>8__locals34.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0087(CS$<>8__locals34.construction, CS$<>8__locals34.reader);
				}
				else if (CS$<>8__locals34.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5856))
				{
					CS$<>8__locals34.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008f(CS$<>8__locals34.construction.Spatial, CS$<>8__locals34.reader);
				}
				else if (CS$<>8__locals34.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5876))
				{
					CS$<>8__locals34.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u008d(CS$<>8__locals34.construction, CS$<>8__locals34.reader);
				}
				else
				{
					CS$<>8__locals34.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals34.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals34.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009b(Construction P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass88 CS$<>8__locals22 = new <>c__DisplayClass88();
		CS$<>8__locals22.construction = P_0;
		CS$<>8__locals22.reader = P_1;
		CS$<>8__locals22.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(124))
			{
				if (CS$<>8__locals22.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5888))
				{
					CS$<>8__locals22.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0086(CS$<>8__locals22.construction, CS$<>8__locals22.reader);
				}
				else if (CS$<>8__locals22.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5914))
				{
					CS$<>8__locals22.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009d(CS$<>8__locals22.construction.LandCadNumbers, CS$<>8__locals22.reader, global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5950));
				}
				else if (CS$<>8__locals22.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(5984))
				{
					CS$<>8__locals22.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009d(CS$<>8__locals22.construction.AscendantCadNumbers, CS$<>8__locals22.reader, global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6030));
				}
				else if (CS$<>8__locals22.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6074))
				{
					CS$<>8__locals22.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009d(CS$<>8__locals22.construction.DescendantCadNumbers, CS$<>8__locals22.reader, global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6122));
				}
				else
				{
					CS$<>8__locals22.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals22.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals22.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009c(Parcel P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass8b CS$<>8__locals22 = new <>c__DisplayClass8b();
		CS$<>8__locals22.landPlot = P_0;
		CS$<>8__locals22.reader = P_1;
		CS$<>8__locals22.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(128))
			{
				if (CS$<>8__locals22.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6170))
				{
					CS$<>8__locals22.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0086(CS$<>8__locals22.landPlot, CS$<>8__locals22.reader);
				}
				else if (CS$<>8__locals22.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6196))
				{
					CS$<>8__locals22.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009d(CS$<>8__locals22.landPlot.IncludedObjects, CS$<>8__locals22.reader, global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6232));
				}
				else if (CS$<>8__locals22.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6266))
				{
					CS$<>8__locals22.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009d(CS$<>8__locals22.landPlot.AscendantCadNumbers, CS$<>8__locals22.reader, global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6312));
				}
				else if (CS$<>8__locals22.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6356))
				{
					CS$<>8__locals22.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009d(CS$<>8__locals22.landPlot.DescendantCadNumbers, CS$<>8__locals22.reader, global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6404));
				}
				else
				{
					CS$<>8__locals22.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals22.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals22.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009d(IList<CadastralNumber> collection, XmlTextReader P_1, string P_2)
	{
		<>c__DisplayClass8e CS$<>8__locals12 = new <>c__DisplayClass8e();
		CS$<>8__locals12.collection = collection;
		CS$<>8__locals12.reader = P_1;
		CS$<>8__locals12.nodeName = P_2;
		CS$<>8__locals12.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals12.reader.LocalName == CS$<>8__locals12.nodeName)
			{
				CS$<>8__locals12.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009e(CS$<>8__locals12.collection, CS$<>8__locals12.reader);
			}
			else
			{
				CS$<>8__locals12.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals12.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals12.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009e(IList<CadastralNumber> collection, XmlTextReader P_1)
	{
		<>c__DisplayClass91 CS$<>8__locals9 = new <>c__DisplayClass91();
		CS$<>8__locals9.collection = collection;
		CS$<>8__locals9.reader = P_1;
		CS$<>8__locals9.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals9.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6450))
			{
				CS$<>8__locals9.collection.Add(new CadastralNumber(CS$<>8__locals9.reader.ReadElementContentAsString()));
			}
			else
			{
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals9.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals9.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0086(CadastralObject P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass94 CS$<>8__locals10 = new <>c__DisplayClass94();
		CS$<>8__locals10.cadastralObject = P_0;
		CS$<>8__locals10.reader = P_1;
		CS$<>8__locals10.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals10.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6474))
			{
				OldNumber oldNumber = new OldNumber();
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0087(oldNumber, CS$<>8__locals10.reader);
				CS$<>8__locals10.cadastralObject.OldNumbers.Add(oldNumber);
			}
			else
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals10.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals10.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0087(OldNumber P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass97 CS$<>8__locals19 = new <>c__DisplayClass97();
		CS$<>8__locals19.oldNumber = P_0;
		CS$<>8__locals19.reader = P_1;
		CS$<>8__locals19.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(132))
			{
				if (CS$<>8__locals19.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6498))
				{
					CS$<>8__locals19.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0094(CS$<>8__locals19.oldNumber.Type, CS$<>8__locals19.reader);
				}
				else if (CS$<>8__locals19.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6524))
				{
					CS$<>8__locals19.oldNumber.Number = CS$<>8__locals19.reader.ReadElementString();
				}
				else if (CS$<>8__locals19.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6540))
				{
					CS$<>8__locals19.oldNumber.AssignmentDate = CS$<>8__locals19.reader.ReadElementString();
				}
				else if (CS$<>8__locals19.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6574))
				{
					CS$<>8__locals19.oldNumber.Assigner = CS$<>8__locals19.reader.ReadElementString();
				}
				else
				{
					CS$<>8__locals19.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals19.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals19.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0088(XmlTextReader P_0, CadastralNumber P_1)
	{
		<>c__DisplayClass9a CS$<>8__locals11 = new <>c__DisplayClass9a();
		CS$<>8__locals11.reader = P_0;
		CS$<>8__locals11.quarterNumber = P_1;
		CS$<>8__locals11.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals11.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6594))
			{
				Parcel parcel = new Parcel();
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(parcel, CS$<>8__locals11.reader);
				parcel.QuarterNumber = CS$<>8__locals11.quarterNumber;
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0091.Add(parcel);
			}
			else
			{
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals11.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals11.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0089(XmlTextReader P_0, CadastralNumber P_1)
	{
		<>c__DisplayClass9d CS$<>8__locals11 = new <>c__DisplayClass9d();
		CS$<>8__locals11.reader = P_0;
		CS$<>8__locals11.quarterNumber = P_1;
		CS$<>8__locals11.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals11.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6620))
			{
				Construction construction = new Construction
				{
					ConstructionType = ConstructionType.Building,
					QuarterNumber = CS$<>8__locals11.quarterNumber
				};
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009a(construction, CS$<>8__locals11.reader);
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0094.Add(construction);
			}
			else
			{
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals11.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals11.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008a(XmlTextReader P_0)
	{
		<>c__DisplayClassa0 CS$<>8__locals9 = new <>c__DisplayClassa0();
		CS$<>8__locals9.reader = P_0;
		CS$<>8__locals9.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals9.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6648))
			{
				Construction construction = new Construction
				{
					ConstructionType = ConstructionType.Construction
				};
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009a(construction, CS$<>8__locals9.reader);
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0094.Add(construction);
			}
			else
			{
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals9.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals9.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008b(XmlTextReader P_0, CadastralNumber P_1)
	{
		<>c__DisplayClassa3 CS$<>8__locals17 = new <>c__DisplayClassa3();
		CS$<>8__locals17.reader = P_0;
		CS$<>8__locals17.quarterNumber = P_1;
		CS$<>8__locals17.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals17.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6690))
			{
				CS$<>8__locals17.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0088(CS$<>8__locals17.reader, CS$<>8__locals17.quarterNumber);
			}
			else if (CS$<>8__locals17.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6718))
			{
				CS$<>8__locals17.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0089(CS$<>8__locals17.reader, CS$<>8__locals17.quarterNumber);
			}
			else if (CS$<>8__locals17.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6748))
			{
				CS$<>8__locals17.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008a(CS$<>8__locals17.reader);
			}
			else
			{
				CS$<>8__locals17.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals17.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals17.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008c(XmlTextReader P_0, CadastralNumber P_1)
	{
		<>c__DisplayClassa6 CS$<>8__locals10 = new <>c__DisplayClassa6();
		CS$<>8__locals10.reader = P_0;
		CS$<>8__locals10.quarterNumber = P_1;
		CS$<>8__locals10.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals10.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6792))
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008b(CS$<>8__locals10.reader, CS$<>8__locals10.quarterNumber);
			}
			else
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals10.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals10.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008d(XmlTextReader P_0)
	{
		<>c__DisplayClassa9 CS$<>8__locals10 = new <>c__DisplayClassa9();
		CS$<>8__locals10.reader = P_0;
		CS$<>8__locals10.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(136))
			{
				if (CS$<>8__locals10.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6814))
				{
					EntitySpatial entitySpatial = new EntitySpatial(CS$<>8__locals10.<>4__this);
					CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0092.Add(entitySpatial);
					CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u008c(entitySpatial, CS$<>8__locals10.reader);
					Borders borders = new Borders();
					foreach (SpatialElement element in entitySpatial.Elements)
					{
						for (int i = 0; i < element.Count - 1; i++)
						{
							borders.Add(new Border
							{
								Spatial = entitySpatial.Elements.Count - 1,
								Point1 = element[i].Number,
								Point2 = element[i + 1].Number
							});
						}
					}
					entitySpatial.Borders.Add(borders);
				}
				else
				{
					CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals10.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals10.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008e(Bound P_0, XmlTextReader P_1)
	{
		<>c__DisplayClassac CS$<>8__locals13 = new <>c__DisplayClassac();
		CS$<>8__locals13.bound = P_0;
		CS$<>8__locals13.reader = P_1;
		CS$<>8__locals13.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6846))
			{
				CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0094(CS$<>8__locals13.bound.Type, CS$<>8__locals13.reader);
			}
			else if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6876))
			{
				CS$<>8__locals13.bound.RegNumbBorder = CS$<>8__locals13.reader.ReadElementContentAsString();
			}
			else
			{
				CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals13.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals13.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008f(Bound P_0, XmlTextReader P_1)
	{
		<>c__DisplayClassaf CS$<>8__locals10 = new <>c__DisplayClassaf();
		CS$<>8__locals10.bound = P_0;
		CS$<>8__locals10.reader = P_1;
		CS$<>8__locals10.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals10.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6910))
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008e(CS$<>8__locals10.bound, CS$<>8__locals10.reader);
			}
			else
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals10.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals10.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0090(ZoneBound P_0, XmlTextReader P_1)
	{
		<>c__DisplayClassb2 CS$<>8__locals20 = new <>c__DisplayClassb2();
		CS$<>8__locals20.bound = P_0;
		CS$<>8__locals20.reader = P_1;
		CS$<>8__locals20.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(140))
			{
				if (CS$<>8__locals20.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6930))
				{
					CS$<>8__locals20.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008e(CS$<>8__locals20.bound, CS$<>8__locals20.reader);
				}
				else if (CS$<>8__locals20.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6950))
				{
					CS$<>8__locals20.bound.Index = CS$<>8__locals20.reader.ReadElementContentAsString();
				}
				else if (CS$<>8__locals20.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6964))
				{
					CS$<>8__locals20.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0094(CS$<>8__locals20.bound.TypeZone, CS$<>8__locals20.reader);
				}
				else if (CS$<>8__locals20.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(6986))
				{
					CS$<>8__locals20.bound.Number = CS$<>8__locals20.reader.ReadElementContentAsString();
				}
				else
				{
					CS$<>8__locals20.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals20.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals20.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0091(CoastlineBound P_0, XmlTextReader P_1)
	{
		<>c__DisplayClassb5 CS$<>8__locals14 = new <>c__DisplayClassb5();
		CS$<>8__locals14.bound = P_0;
		CS$<>8__locals14.reader = P_1;
		CS$<>8__locals14.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals14.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7002))
			{
				CS$<>8__locals14.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008e(CS$<>8__locals14.bound, CS$<>8__locals14.reader);
			}
			else if (CS$<>8__locals14.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7022))
			{
				CS$<>8__locals14.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0092(CS$<>8__locals14.bound, CS$<>8__locals14.reader);
			}
			else
			{
				CS$<>8__locals14.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals14.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals14.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0092(CoastlineBound P_0, XmlTextReader P_1)
	{
		<>c__DisplayClassb8 CS$<>8__locals13 = new <>c__DisplayClassb8();
		CS$<>8__locals13.bound = P_0;
		CS$<>8__locals13.reader = P_1;
		CS$<>8__locals13.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7036))
			{
				CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0094(CS$<>8__locals13.bound.WaterObjectType, CS$<>8__locals13.reader);
			}
			else if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7074))
			{
				CS$<>8__locals13.bound.WaterObjectName = CS$<>8__locals13.reader.ReadElementContentAsString();
			}
			else
			{
				CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals13.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals13.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0093(Bound P_0, XmlTextReader P_1)
	{
		<>c__DisplayClassbb CS$<>8__locals17 = new <>c__DisplayClassbb();
		CS$<>8__locals17.bound = P_0;
		CS$<>8__locals17.reader = P_1;
		CS$<>8__locals17.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals17.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7112))
			{
				CS$<>8__locals17.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0093(CS$<>8__locals17.bound, CS$<>8__locals17.reader);
			}
			else if (CS$<>8__locals17.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7154))
			{
				CS$<>8__locals17.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008f(CS$<>8__locals17.bound, CS$<>8__locals17.reader);
			}
			else if (CS$<>8__locals17.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7212))
			{
				CS$<>8__locals17.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals17.reader);
			}
			else
			{
				CS$<>8__locals17.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals17.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals17.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0094(Bound P_0, XmlTextReader P_1)
	{
		<>c__DisplayClassbe CS$<>8__locals18 = new <>c__DisplayClassbe();
		CS$<>8__locals18.bound = P_0;
		CS$<>8__locals18.reader = P_1;
		CS$<>8__locals18.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(144))
			{
				if (CS$<>8__locals18.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7238))
				{
					CS$<>8__locals18.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0093(CS$<>8__locals18.bound, CS$<>8__locals18.reader);
				}
				else if (CS$<>8__locals18.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7280))
				{
					CS$<>8__locals18.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008f(CS$<>8__locals18.bound, CS$<>8__locals18.reader);
				}
				else if (CS$<>8__locals18.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7356))
				{
					CS$<>8__locals18.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0096(CS$<>8__locals18.bound, CS$<>8__locals18.reader);
				}
				else
				{
					CS$<>8__locals18.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals18.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals18.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0095(CoastlineBound P_0, XmlTextReader P_1)
	{
		<>c__DisplayClassc1 CS$<>8__locals18 = new <>c__DisplayClassc1();
		CS$<>8__locals18.bound = P_0;
		CS$<>8__locals18.reader = P_1;
		CS$<>8__locals18.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(148))
			{
				if (CS$<>8__locals18.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7382))
				{
					CS$<>8__locals18.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0093(CS$<>8__locals18.bound, CS$<>8__locals18.reader);
				}
				else if (CS$<>8__locals18.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7424))
				{
					CS$<>8__locals18.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0091(CS$<>8__locals18.bound, CS$<>8__locals18.reader);
				}
				else if (CS$<>8__locals18.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7488))
				{
					CS$<>8__locals18.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0096(CS$<>8__locals18.bound, CS$<>8__locals18.reader);
				}
				else
				{
					CS$<>8__locals18.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals18.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals18.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0096(Bound P_0, XmlTextReader P_1)
	{
		<>c__DisplayClassc4 CS$<>8__locals9 = new <>c__DisplayClassc4();
		CS$<>8__locals9.bound = P_0;
		CS$<>8__locals9.reader = P_1;
		CS$<>8__locals9.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals9.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7514))
			{
				CS$<>8__locals9.bound.RegistrationDate = CS$<>8__locals9.reader.ReadElementContentAsString();
			}
			else
			{
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals9.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals9.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0097(ZoneBound P_0, XmlTextReader P_1)
	{
		<>c__DisplayClassc7 CS$<>8__locals17 = new <>c__DisplayClassc7();
		CS$<>8__locals17.bound = P_0;
		CS$<>8__locals17.reader = P_1;
		CS$<>8__locals17.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals17.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7552))
			{
				CS$<>8__locals17.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0093(CS$<>8__locals17.bound, CS$<>8__locals17.reader);
			}
			else if (CS$<>8__locals17.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7594))
			{
				CS$<>8__locals17.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0090(CS$<>8__locals17.bound, CS$<>8__locals17.reader);
			}
			else if (CS$<>8__locals17.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7658))
			{
				CS$<>8__locals17.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals17.reader);
			}
			else
			{
				CS$<>8__locals17.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals17.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals17.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0098(XmlTextReader P_0)
	{
		<>c__DisplayClassca CS$<>8__locals9 = new <>c__DisplayClassca();
		CS$<>8__locals9.reader = P_0;
		CS$<>8__locals9.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals9.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7684))
			{
				ZoneBound zoneBound = new ZoneBound();
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0097(zoneBound, CS$<>8__locals9.reader);
				if (zoneBound.RegNumbBorder != string.Empty)
				{
					CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0093[zoneBound.RegNumbBorder] = zoneBound;
				}
			}
			else
			{
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals9.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals9.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0099(XmlTextReader P_0)
	{
		<>c__DisplayClasscd CS$<>8__locals9 = new <>c__DisplayClasscd();
		CS$<>8__locals9.reader = P_0;
		CS$<>8__locals9.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals9.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7744))
			{
				Bound bound = new Bound(BoundType.Municipal);
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0093(bound, CS$<>8__locals9.reader);
				if (bound.RegNumbBorder != string.Empty)
				{
					CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0093[bound.RegNumbBorder] = bound;
				}
			}
			else
			{
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals9.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals9.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u009a(XmlTextReader P_0)
	{
		<>c__DisplayClassd0 CS$<>8__locals9 = new <>c__DisplayClassd0();
		CS$<>8__locals9.reader = P_0;
		CS$<>8__locals9.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals9.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7798))
			{
				Bound bound = new Bound(BoundType.InhabitedLocality);
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0094(bound, CS$<>8__locals9.reader);
				if (bound.RegNumbBorder != string.Empty)
				{
					CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0093[bound.RegNumbBorder] = bound;
				}
			}
			else
			{
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals9.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals9.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u009b(XmlTextReader P_0)
	{
		<>c__DisplayClassd3 CS$<>8__locals9 = new <>c__DisplayClassd3();
		CS$<>8__locals9.reader = P_0;
		CS$<>8__locals9.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals9.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7870))
			{
				CoastlineBound coastlineBound = new CoastlineBound();
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0095(coastlineBound, CS$<>8__locals9.reader);
				if (coastlineBound.RegNumbBorder != string.Empty)
				{
					CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0093[coastlineBound.RegNumbBorder] = coastlineBound;
				}
			}
			else
			{
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals9.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals9.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u009c(XmlTextReader P_0)
	{
		<>c__DisplayClassd6 CS$<>8__locals31 = new <>c__DisplayClassd6();
		CS$<>8__locals31.reader = P_0;
		CS$<>8__locals31.<>4__this = this;
		CS$<>8__locals31.quarterNumber = null;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(152))
			{
				if (CS$<>8__locals31.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7906))
				{
					CS$<>8__locals31.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008c(CS$<>8__locals31.reader, CS$<>8__locals31.quarterNumber);
				}
				else if (CS$<>8__locals31.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7932))
				{
					CS$<>8__locals31.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u008d(CS$<>8__locals31.reader);
				}
				else if (CS$<>8__locals31.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(7960))
				{
					CS$<>8__locals31.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0098(CS$<>8__locals31.reader);
				}
				else if (CS$<>8__locals31.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8028))
				{
					CS$<>8__locals31.quarterNumber = new CadastralNumber(CS$<>8__locals31.reader.ReadElementContentAsString());
				}
				else if (CS$<>8__locals31.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8064))
				{
					CS$<>8__locals31.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals31.reader);
				}
				else if (CS$<>8__locals31.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8092))
				{
					CS$<>8__locals31.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u0099(CS$<>8__locals31.reader);
				}
				else if (CS$<>8__locals31.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8136))
				{
					CS$<>8__locals31.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u009a(CS$<>8__locals31.reader);
				}
				else if (CS$<>8__locals31.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8198))
				{
					CS$<>8__locals31.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u009b(CS$<>8__locals31.reader);
				}
				else
				{
					CS$<>8__locals31.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals31.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals31.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u009d(XmlTextReader P_0)
	{
		<>c__DisplayClassd9 CS$<>8__locals8 = new <>c__DisplayClassd9();
		CS$<>8__locals8.reader = P_0;
		CS$<>8__locals8.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals8.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8242))
			{
				CS$<>8__locals8.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u009c(CS$<>8__locals8.reader);
			}
			else
			{
				CS$<>8__locals8.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals8.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals8.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u009e(XmlTextReader P_0, string P_1, ConstructionType P_2)
	{
		<>c__DisplayClassdc CS$<>8__locals19 = new <>c__DisplayClassdc();
		CS$<>8__locals19.reader = P_0;
		CS$<>8__locals19.recordNodeName = P_1;
		CS$<>8__locals19.constructionType = P_2;
		CS$<>8__locals19.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(156))
			{
				if (CS$<>8__locals19.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8276))
				{
					CS$<>8__locals19.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(CS$<>8__locals19.reader);
				}
				else if (CS$<>8__locals19.reader.LocalName == CS$<>8__locals19.recordNodeName)
				{
					Construction construction = new Construction
					{
						ConstructionType = CS$<>8__locals19.constructionType
					};
					CS$<>8__locals19.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u009a(construction, CS$<>8__locals19.reader);
					CS$<>8__locals19.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0094.Add(construction);
				}
				else if (CS$<>8__locals19.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8310))
				{
					CS$<>8__locals19.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0087(CS$<>8__locals19.reader);
				}
				else
				{
					CS$<>8__locals19.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals19.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals19.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0086(XmlTextReader P_0)
	{
		<>c__DisplayClassdf CS$<>8__locals15 = new <>c__DisplayClassdf();
		CS$<>8__locals15.reader = P_0;
		CS$<>8__locals15.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(160))
			{
				if (CS$<>8__locals15.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8340))
				{
					CS$<>8__locals15.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(CS$<>8__locals15.reader);
				}
				else if (CS$<>8__locals15.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8374))
				{
					Parcel parcel = new Parcel();
					CS$<>8__locals15.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(parcel, CS$<>8__locals15.reader);
					CS$<>8__locals15.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0091.Add(parcel);
				}
				else if (CS$<>8__locals15.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8400))
				{
					CS$<>8__locals15.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0087(CS$<>8__locals15.reader);
				}
				else
				{
					CS$<>8__locals15.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals15.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals15.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0087(XmlTextReader P_0)
	{
		<>c__DisplayClasse2 CS$<>8__locals11 = new <>c__DisplayClasse2();
		CS$<>8__locals11.reader = P_0;
		CS$<>8__locals11.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals11.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8430))
			{
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(CS$<>8__locals11.reader);
			}
			else if (CS$<>8__locals11.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8464))
			{
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0088\u009d(CS$<>8__locals11.reader);
			}
			else
			{
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals11.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals11.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(Action P_0, XmlTextReader P_1)
	{
		if (!P_1.Read())
		{
			return;
		}
		int depth = P_1.Depth;
		while (P_1.Depth >= depth)
		{
			if (P_1.NodeType == XmlNodeType.Element)
			{
				P_0();
				continue;
			}
			_ = P_1.NodeType;
			_ = 13;
			\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
		}
		if (P_1.NodeType == XmlNodeType.EndElement)
		{
			\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0089(XmlTextReader P_0)
	{
		if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(12) || !P_0.Read())
		{
			return;
		}
		int depth = P_0.Depth;
		while (P_0.Depth >= depth)
		{
			if (P_0.NodeType == XmlNodeType.Element)
			{
				if (P_0.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(732))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008b(P_0);
					if (P_0.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_0);
					}
				}
				if (P_0.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(750))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u009b(\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0094, P_0);
				}
				else if (P_0.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(780))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0095(this, \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0092, P_0);
				}
				else if (P_0.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(806))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0096(P_0);
				}
				else if (P_0.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(822))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0099(P_0);
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_0);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_0);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(XmlTextReader P_0)
	{
		while (P_0.NodeType == XmlNodeType.Whitespace)
		{
			P_0.Read();
		}
		P_0.Skip();
		int depth = P_0.Depth;
		while (depth == P_0.Depth && (P_0.NodeType == XmlNodeType.Whitespace || P_0.NodeType == XmlNodeType.EndElement))
		{
			P_0.Read();
		}
		while (P_0.NodeType == XmlNodeType.Whitespace)
		{
			P_0.Read();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008b(XmlTextReader P_0)
	{
		if (!P_0.Read())
		{
			return;
		}
		int depth = P_0.Depth;
		while (P_0.Depth >= depth)
		{
			if (P_0.NodeType == XmlNodeType.Element)
			{
				if (P_0.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(836))
				{
					Parcel parcel = new Parcel();
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0090(parcel, P_0);
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0091.Add(parcel);
					if (P_0.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_0);
					}
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_0);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_0);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008c(Parcel P_0, XmlTextReader P_1)
	{
		if (!P_1.Read())
		{
			return;
		}
		int depth = P_1.Depth;
		while (P_1.Depth >= depth)
		{
			if (P_1.NodeType == XmlNodeType.Element)
			{
				if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(852))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0092(P_0.Spatial, P_1);
					if (P_1.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
					}
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008d(Parcel P_0, XmlTextReader P_1)
	{
		if (!P_1.Read())
		{
			return;
		}
		int depth = P_1.Depth;
		while (P_1.Depth >= depth)
		{
			if (P_1.NodeType == XmlNodeType.Element)
			{
				if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(882))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008c(P_0, P_1);
					if (P_1.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
					}
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008e(Restriction P_0, XmlTextReader P_1)
	{
		<>c__DisplayClasse5 CS$<>8__locals12 = new <>c__DisplayClasse5();
		CS$<>8__locals12.restriction = P_0;
		CS$<>8__locals12.reader = P_1;
		CS$<>8__locals12.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals12.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8500))
			{
				CS$<>8__locals12.restriction.Type.Code = CS$<>8__locals12.reader.ReadContentAsString();
			}
			else if (CS$<>8__locals12.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8512))
			{
				CS$<>8__locals12.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals12.reader);
			}
			else
			{
				CS$<>8__locals12.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals12.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals12.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008f(LandPlotPart P_0, XmlTextReader P_1)
	{
		if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(16))
		{
			return;
		}
		P_0.Number = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(900));
		if (!P_1.Read())
		{
			return;
		}
		int depth = P_1.Depth;
		while (P_1.Depth >= depth)
		{
			if (P_1.NodeType == XmlNodeType.Element)
			{
				if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(928))
				{
					Restriction restriction = new Restriction();
					restriction.PartNumber = P_0.Number;
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008e(restriction, P_1);
					P_0.Parcel.Restrictions.Add(restriction);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(954))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0092(P_0.Spatial, P_1);
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0090(Parcel P_0, XmlTextReader P_1)
	{
		if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(20))
		{
			return;
		}
		string attribute = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(984));
		if (!string.IsNullOrEmpty(attribute))
		{
			P_0.CadastralNumber = new CadastralNumber(attribute);
		}
		P_0.RegistrationDate = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1018));
		if (!P_1.Read())
		{
			return;
		}
		int depth = P_1.Depth;
		while (P_1.Depth >= depth)
		{
			if (P_1.NodeType == XmlNodeType.Element)
			{
				if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1044))
				{
					P_0.Area = \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0091(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1056))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0092(P_0.Spatial, P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1086))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1112))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1144))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1156))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1200))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0086(P_0.Addresses, P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1220))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1240))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1266))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1282))
				{
					if (!P_1.Read())
					{
						continue;
					}
					int depth2 = P_1.Depth;
					while (P_1.Depth >= depth2)
					{
						if (P_1.NodeType == XmlNodeType.Element)
						{
							if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1306))
							{
								LandPlotPart landPlotPart = new LandPlotPart(P_0);
								\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008f(landPlotPart, P_1);
								P_0.AddSubParcel(landPlotPart);
							}
							else
							{
								\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
							}
						}
						else
						{
							\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
						}
					}
					if (P_1.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
					}
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1328))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1358))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1386))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1416))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1442))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1466))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1512))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008d(P_0, P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1532))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1580))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private string \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0091(XmlTextReader P_0)
	{
		string result = default(string);
		int depth = default(int);
		if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(24))
		{
			result = string.Empty;
			if (!P_0.Read())
			{
				goto IL_00e9;
			}
			depth = P_0.Depth;
		}
		while (P_0.Depth >= depth)
		{
			if (P_0.NodeType == XmlNodeType.Element)
			{
				if (P_0.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1620))
				{
					result = P_0.ReadElementString();
				}
				else if (P_0.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1632))
				{
					P_0.ReadElementContentAsString();
				}
				else if (P_0.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1644))
				{
					P_0.ReadElementContentAsString();
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_0);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_0);
			}
		}
		if (P_0.NodeType == XmlNodeType.EndElement)
		{
			\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_0);
		}
		goto IL_00e9;
		IL_00e9:
		return result;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0092(EntitySpatial P_0, XmlTextReader P_1)
	{
		if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(28))
		{
			return;
		}
		P_0.Sk_Id = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1668));
		if (P_0.Sk_Id == null)
		{
			P_0.Sk_Id = string.Empty;
		}
		if (!P_1.Read())
		{
			return;
		}
		int depth = P_1.Depth;
		while (P_1.Depth >= depth)
		{
			if (P_1.NodeType == XmlNodeType.Element)
			{
				if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1684))
				{
					SpatialElement spatialElement = new SpatialElement(P_0);
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0093(spatialElement, P_1);
					P_0.Elements.Add(spatialElement);
					if (P_1.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
					}
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1716))
				{
					Borders borders = new Borders();
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0094(borders, P_1);
					P_0.Borders.Add(borders);
					if (P_1.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
					}
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0093(SpatialElement P_0, XmlTextReader P_1)
	{
		if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(32) || !P_1.Read())
		{
			return;
		}
		int depth = P_1.Depth;
		while (P_1.Depth >= depth)
		{
			if (P_1.NodeType == XmlNodeType.Element)
			{
				if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1734))
				{
					string attribute = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1764));
					if (attribute != null && int.TryParse(attribute, out var result))
					{
						if (!P_1.Read())
						{
							continue;
						}
						SpelementUnit spelementUnit = new SpelementUnit();
						int depth2 = P_1.Depth;
						while (P_1.Depth >= depth2)
						{
							if (P_1.NodeType == XmlNodeType.Element)
							{
								double result2;
								if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1778))
								{
									if ((attribute = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1798))) != null)
									{
										double x = double.Parse(attribute, CultureInfo.InvariantCulture);
										if ((attribute = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1804))) != null)
										{
											double y = double.Parse(attribute, CultureInfo.InvariantCulture);
											spelementUnit.X = x;
											spelementUnit.Y = y;
											spelementUnit.Number = result;
											P_0.Add(spelementUnit);
										}
									}
								}
								else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1810) && double.TryParse(P_1.ReadElementContentAsString(), NumberStyles.Float, CultureInfo.InvariantCulture, out result2))
								{
									spelementUnit.R = result2;
								}
								\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
							}
							else
							{
								\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
							}
						}
					}
					else
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
					}
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0094(Borders P_0, XmlTextReader P_1)
	{
		if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(36) || !P_1.Read())
		{
			return;
		}
		int depth = P_1.Depth;
		while (P_1.Depth >= depth)
		{
			if (P_1.NodeType == XmlNodeType.Element)
			{
				if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1816))
				{
					string attribute = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1832));
					if (attribute != null && int.TryParse(attribute, out var result))
					{
						attribute = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1848));
						if (attribute != null && int.TryParse(attribute, out var result2))
						{
							Border border = new Border();
							border.Point1 = result;
							border.Point2 = result2;
							attribute = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1864));
							if (attribute != null && int.TryParse(attribute, out var result3))
							{
								border.Spatial = result3;
							}
							P_0.Add(border);
						}
					}
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0095(object P_0, List<EntitySpatial> data, XmlTextReader P_2)
	{
		if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(40) || !P_2.Read())
		{
			return;
		}
		int depth = P_2.Depth;
		while (P_2.Depth >= depth)
		{
			if (P_2.NodeType == XmlNodeType.Element)
			{
				if (P_2.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1882))
				{
					EntitySpatial entitySpatial = new EntitySpatial(P_0);
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0092(entitySpatial, P_2);
					data.Add(entitySpatial);
					if (P_2.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_2);
					}
				}
				else if (P_2.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1912))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_2);
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_2);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_2);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0096(XmlTextReader P_0)
	{
		if (!P_0.Read())
		{
			return;
		}
		int depth = P_0.Depth;
		while (P_0.Depth >= depth)
		{
			if (P_0.NodeType == XmlNodeType.Element)
			{
				if (P_0.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1934))
				{
					ZoneBound zoneBound = new ZoneBound();
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0097(zoneBound, P_0);
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0093[zoneBound.RegNumbBorder] = zoneBound;
					if (P_0.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_0);
					}
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_0);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_0);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0097(Bound P_0, XmlTextReader P_1)
	{
		if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(44) || !P_1.Read())
		{
			return;
		}
		int depth = P_1.Depth;
		while (P_1.Depth >= depth)
		{
			if (P_1.NodeType == XmlNodeType.Element)
			{
				if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1948))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0098(P_0, P_1);
					if (P_1.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
					}
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1972))
				{
					P_0.Type.Value = P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(1998))
				{
					P_0.RegNumbBorder = P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2028))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2050))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2104))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0098(Bound P_0, XmlTextReader P_1)
	{
		if (!P_1.Read())
		{
			return;
		}
		int depth = P_1.Depth;
		while (P_1.Depth >= depth)
		{
			if (P_1.NodeType == XmlNodeType.Element)
			{
				if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2142))
				{
					Boundary boundary = new Boundary(P_0);
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0095(boundary, boundary, P_1);
					P_0.Boundaries.Add(boundary);
					if (P_1.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
					}
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0099(XmlTextReader P_0)
	{
		if (!P_0.Read())
		{
			return;
		}
		int depth = P_0.Depth;
		while (P_0.Depth >= depth)
		{
			if (P_0.NodeType == XmlNodeType.Element)
			{
				if (P_0.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2162))
				{
					ZoneBound zoneBound = new ZoneBound();
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u009a(zoneBound, P_0);
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0093[zoneBound.RegNumbBorder] = zoneBound;
					if (P_0.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_0);
					}
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_0);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_0);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u009a(ZoneBound P_0, XmlTextReader P_1)
	{
		if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(48) || !P_1.Read())
		{
			return;
		}
		int depth = P_1.Depth;
		while (P_1.Depth >= depth)
		{
			if (P_1.NodeType == XmlNodeType.Element)
			{
				if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2174))
				{
					if (P_0.Boundaries.Count == 0)
					{
						Boundary boundary = new Boundary(P_0);
						boundary.Add(new EntitySpatial(boundary));
						P_0.Boundaries.Add(boundary);
					}
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0092(P_0.Boundaries.First().First(), P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2204))
				{
					P_0.Type.Value = P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2230))
				{
					P_0.RegNumbBorder = P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2260))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2282))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2308))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u009b(List<Construction> realities, XmlTextReader P_1)
	{
		if (!P_1.Read())
		{
			return;
		}
		int depth = P_1.Depth;
		while (P_1.Depth >= depth)
		{
			if (P_1.NodeType == XmlNodeType.Element)
			{
				if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2342))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u009c(realities, P_1);
					if (P_1.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
					}
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u009c(List<Construction> realities, XmlTextReader P_1)
	{
		if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(52) || !P_1.Read())
		{
			return;
		}
		int depth = P_1.Depth;
		while (P_1.Depth >= depth)
		{
			if (P_1.NodeType == XmlNodeType.Element)
			{
				if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2370))
				{
					Construction construction = new Construction();
					construction.ConstructionType = ConstructionType.Building;
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u009d(construction, P_1);
					realities.Add(construction);
					if (P_1.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
					}
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2390))
				{
					Construction construction2 = new Construction();
					construction2.ConstructionType = ConstructionType.Construction;
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u009d(construction2, P_1);
					realities.Add(construction2);
					if (P_1.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
					}
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2418))
				{
					Construction construction3 = new Construction();
					construction3.ConstructionType = ConstructionType.Uncompleted;
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u009d(construction3, P_1);
					realities.Add(construction3);
					if (P_1.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
					}
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u009d(Construction P_0, XmlTextReader P_1)
	{
		if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(56))
		{
			return;
		}
		P_0.CadastralNumber = new CadastralNumber(P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2444)));
		if (!P_1.Read())
		{
			return;
		}
		int depth = P_1.Depth;
		while (P_1.Depth >= depth)
		{
			if (P_1.NodeType == XmlNodeType.Element)
			{
				if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2478))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0092(P_0.Spatial, P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2508))
				{
					P_0.Assignation = P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2550))
				{
					P_0.Assignation = P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2584))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u009e(P_0.Address, P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2602))
				{
					P_0.Area = P_1.ReadElementContentAsString();
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u009e(Address P_0, XmlTextReader P_1)
	{
		if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(60) || !P_1.Read())
		{
			return;
		}
		int depth = P_1.Depth;
		while (P_1.Depth >= depth)
		{
			if (P_1.NodeType == XmlNodeType.Element)
			{
				if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2614))
				{
					P_0.OKATO = P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2628))
				{
					P_0.KLADR = P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2642))
				{
					P_0.Region = P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2658))
				{
					P_0.City = new Address.TypedString
					{
						Value = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2670)),
						Type = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2682))
					};
					P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2694))
				{
					P_0.District = new Address.TypedString
					{
						Value = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2714)),
						Type = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2726))
					};
					P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2738))
				{
					P_0.Locality = new Address.TypedString
					{
						Value = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2758)),
						Type = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2770))
					};
					P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2782))
				{
					P_0.Street = new Address.TypedString
					{
						Value = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2798)),
						Type = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2810))
					};
					P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2822))
				{
					P_0.Level1 = new Address.TypedString
					{
						Value = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2838)),
						Type = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2852))
					};
					P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2864))
				{
					P_0.Level2 = new Address.TypedString
					{
						Value = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2880)),
						Type = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2894))
					};
					P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2906))
				{
					P_0.Level3 = new Address.TypedString
					{
						Value = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2922)),
						Type = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2936))
					};
					P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2948))
				{
					P_0.Apartment = new Address.TypedString
					{
						Value = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2970)),
						Type = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2984))
					};
					P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(2996))
				{
					P_0.UrbanDistrict = new Address.TypedString
					{
						Value = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3026)),
						Type = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3038))
					};
					P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3050))
				{
					P_0.SovietVillage = new Address.TypedString
					{
						Value = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3080)),
						Type = P_1.GetAttribute(global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3092))
					};
					P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3104))
				{
					P_0.Other = P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3118))
				{
					P_0.Note = P_1.ReadElementContentAsString();
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3130))
				{
					P_0.PostalCode = P_1.ReadElementContentAsString();
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
			}
		}
		if (P_1.NodeType == XmlNodeType.EndElement)
		{
			\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0086(IList<Address> location, XmlTextReader P_1)
	{
		if (global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(64) || !P_1.Read())
		{
			return;
		}
		int depth = P_1.Depth;
		while (P_1.Depth >= depth)
		{
			if (P_1.NodeType == XmlNodeType.Element)
			{
				if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3154))
				{
					Address address = new Address();
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u009e(address, P_1);
					location.Add(address);
					if (P_1.NodeType == XmlNodeType.EndElement)
					{
						\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
					}
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3172))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3198))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else if (P_1.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(3218))
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
				else
				{
					\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
				}
			}
			else
			{
				\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(P_1);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0087(XmlTextReader P_0)
	{
		<>c__DisplayClassf2 CS$<>8__locals9 = new <>c__DisplayClassf2();
		CS$<>8__locals9.reader = P_0;
		CS$<>8__locals9.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals9.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8524))
			{
				RightRecord rightRecord = new RightRecord();
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0088(rightRecord, CS$<>8__locals9.reader);
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0095.Add(rightRecord);
			}
			else
			{
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals9.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals9.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0088(RightRecord P_0, XmlTextReader P_1)
	{
		<>c__DisplayClassf5 CS$<>8__locals18 = new <>c__DisplayClassf5();
		CS$<>8__locals18.rightRecord = P_0;
		CS$<>8__locals18.reader = P_1;
		CS$<>8__locals18.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (!global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0087(164))
			{
				if (CS$<>8__locals18.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8552))
				{
					CS$<>8__locals18.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0089(CS$<>8__locals18.rightRecord, CS$<>8__locals18.reader);
				}
				else if (CS$<>8__locals18.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8578))
				{
					CS$<>8__locals18.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0089(CS$<>8__locals18.rightRecord, CS$<>8__locals18.reader);
				}
				else if (CS$<>8__locals18.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8602))
				{
					CS$<>8__locals18.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008a(CS$<>8__locals18.rightRecord, CS$<>8__locals18.reader);
				}
				else
				{
					CS$<>8__locals18.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals18.reader);
				}
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals18.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u0089(RightRecord P_0, XmlTextReader P_1)
	{
		<>c__DisplayClassf8 CS$<>8__locals13 = new <>c__DisplayClassf8();
		CS$<>8__locals13.rightRecord = P_0;
		CS$<>8__locals13.reader = P_1;
		CS$<>8__locals13.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8632))
			{
				CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0087\u0094(CS$<>8__locals13.rightRecord.RightType, CS$<>8__locals13.reader);
			}
			else if (CS$<>8__locals13.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8656))
			{
				CS$<>8__locals13.rightRecord.RightNumber = CS$<>8__locals13.reader.ReadElementContentAsString();
			}
			else
			{
				CS$<>8__locals13.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals13.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals13.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008a(RightRecord P_0, XmlTextReader P_1)
	{
		<>c__DisplayClassfb CS$<>8__locals10 = new <>c__DisplayClassfb();
		CS$<>8__locals10.rightRecord = P_0;
		CS$<>8__locals10.reader = P_1;
		CS$<>8__locals10.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals10.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8684))
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008b(CS$<>8__locals10.rightRecord, CS$<>8__locals10.reader);
			}
			else
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals10.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals10.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008b(RightRecord P_0, XmlTextReader P_1)
	{
		<>c__DisplayClassfe CS$<>8__locals11 = new <>c__DisplayClassfe();
		CS$<>8__locals11.reader = P_1;
		CS$<>8__locals11.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			RightHolder rightHolder = new RightHolder();
			if (CS$<>8__locals11.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8712))
			{
				rightHolder.Individual = false;
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008d(rightHolder, CS$<>8__locals11.reader);
			}
			else if (CS$<>8__locals11.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8748))
			{
				rightHolder.Individual = true;
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008c(rightHolder, CS$<>8__locals11.reader);
			}
			else
			{
				CS$<>8__locals11.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals11.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals11.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008c(RightHolder P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass101 CS$<>8__locals9 = new <>c__DisplayClass101();
		CS$<>8__locals9.rightHolder = P_0;
		CS$<>8__locals9.reader = P_1;
		CS$<>8__locals9.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals9.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8772))
			{
				CS$<>8__locals9.rightHolder.Name = CS$<>8__locals9.reader.ReadElementContentAsString();
			}
			else
			{
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals9.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals9.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008d(RightHolder P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass104 CS$<>8__locals10 = new <>c__DisplayClass104();
		CS$<>8__locals10.rightHolder = P_0;
		CS$<>8__locals10.reader = P_1;
		CS$<>8__locals10.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals10.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8784))
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008e(CS$<>8__locals10.rightHolder, CS$<>8__locals10.reader);
			}
			else
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals10.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals10.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008e(RightHolder P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass107 CS$<>8__locals10 = new <>c__DisplayClass107();
		CS$<>8__locals10.rightHolder = P_0;
		CS$<>8__locals10.reader = P_1;
		CS$<>8__locals10.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals10.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8830))
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008f(CS$<>8__locals10.rightHolder, CS$<>8__locals10.reader);
			}
			else
			{
				CS$<>8__locals10.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals10.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals10.reader);
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void \u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u008a\u008f(RightHolder P_0, XmlTextReader P_1)
	{
		<>c__DisplayClass10a CS$<>8__locals9 = new <>c__DisplayClass10a();
		CS$<>8__locals9.rightHolder = P_0;
		CS$<>8__locals9.reader = P_1;
		CS$<>8__locals9.<>4__this = this;
		Action action = [MethodImpl(MethodImplOptions.NoInlining)] () =>
		{
			if (CS$<>8__locals9.reader.LocalName == global::\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0093.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0092.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0086\u0088(8858))
			{
				CS$<>8__locals9.rightHolder.Name = CS$<>8__locals9.reader.ReadElementContentAsString();
			}
			else
			{
				CS$<>8__locals9.<>4__this.\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u008a(CS$<>8__locals9.reader);
			}
		};
		\u0086\u0086\u0086\u000d\u000a\u0086\u0086\u0086\u0086\u0089\u0088(action, CS$<>8__locals9.reader);
	}
}
