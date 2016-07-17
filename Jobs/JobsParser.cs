using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using Jobs.Models;

namespace Jobs
{
	public class JobsParser
	{
		private const string SiteUrl = "https://job.ru";
		private const string AllViewsSelector = "div.sr_row";

		private readonly string _categoryUri;

		public JobsParser(JobsParserSettings settings)
		{
			_categoryUri = settings.CategoryUri;
		}

		public async Task<IEnumerable<Applicant>> ParseAsync()
		{
			// Setup the configuration to support document loading
			var config = Configuration.Default.WithDefaultLoader().WithCookies();
			
			// Asynchronously get the document in a new context using the configuration
			var document = await BrowsingContext.New(config).OpenAsync(_categoryUri);

			// Perform the query to get all applicant's views
			var views = document.QuerySelectorAll(AllViewsSelector);

			var applicants = new ConcurrentQueue<Applicant>();

			foreach (var view in views)
			{
				applicants.Enqueue(await ParseView(view));
			}

			return applicants;
		}

		/// <summary>
		///     Parse html view of applicant.
		///     Example of DOM below:
		/// </summary>
		/// <c>
		///     <div class="sr_row">
		///         <div class="interval_2"></div>
		///         <div class="avatar_col">
		///             <span class="sr_date">12.07.16</span>
		///             <div class="interval_2"></div>
		///             <a class="wrapTD" href="/resume/6495946">
		///                 <img src="http://img1.job.ru/fe/upload/seeker/logo/p/i/g/h/pigh5mlspuwulqw9lvztaw2-thumbnew.jpg"
		///                     alt="Фото Соискателя">
		///             </a>
		///         </div>
		///         <div class="sr_descr">
		///             <div class="row">
		///                 <div class="sr_salary">от&nbsp;<b>90&nbsp;000 руб.</b></div>
		///                 <a class="sr_name" target="_blank" href="/resume/6495946">Административный директор</a>
		///             </div>
		///             <div class="interval_2"></div>
		///             <div class="sr_seeker_info">
		///                 <span>М</span>, 49 лет, высшее образование, г.&nbsp;Кострома, гр.&nbsp;Россия, готов к переезду
		///             </div>
		///             <div class="interval_2"></div>
		///             <dl>
		///                 <dt>Сейчас</dt>
		///                 <dd>
		///                     <div>
		///                         <b>Специалист по охране труда</b>
		///                     </div>
		///                     <div>1 год и 11 месяцев, ООО НОВАТЭК-Кострома</div>
		///                 </dd>
		///             </dl>
		///             <div class="interval_3"></div>
		///             <dl>
		///                 <dt>Ранее</dt>
		///                 <dd>
		///                     <div>
		///                         <b>Место работы не указано</b>
		///                     </div>
		///                     <div>1 год и 9 месяцев</div>
		///                 </dd>
		///             </dl>
		///             <div class="interval_2"></div>
		///             <dl>
		///                 <dt>&nbsp;</dt>
		///                 <dd>
		///                     <div class="grey">
		///                         <i>Всего 3 места работы за 23 года и 1 месяц</i>
		///                     </div>
		///                 </dd>
		///             </dl>
		///             <div class="interval_2"></div>
		///             <div class="sr_seeker_contact">
		///                 <span class="cv_id" style="display: none;">6495946</span>
		///                 <span class="fio_switch">
		///                     <i class="ico-set ico-lock"></i>
		///                     <span class="a dotted">ФИО и контактные данные</span>
		///                 </span>
		///                 <div class="sr_seeker_contact_info" style="display:none;"></div>
		///             </div>
		///         </div>
		///         <div class="interval_2"></div>
		///     </div>
		/// </c>
		/// <param name="view">
		///     html representation of applicant
		/// </param>
		/// <returns>
		///     Filled Apllicant Model
		/// </returns>
		private static Task<Applicant> ParseView(IElement view)
		{
			return Task<Applicant>.Factory.StartNew(() => new ApplicantHtmlViewParser(view, SiteUrl).Parse());
		}
	}
}
