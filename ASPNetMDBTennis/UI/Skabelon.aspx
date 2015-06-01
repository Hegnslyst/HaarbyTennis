<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/SiteOrange.Master" AutoEventWireup="true" CodeBehind="Skabelon.aspx.cs" Inherits="ASPNetMDBTennis.UI.Skabelon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

     <h1 class="first">&lt;H1&gt; Header</h1>
                    <div class="photo-container align-left" style="width:202px;">
                        <div class="photo-content"> <img src="../../Content/images/photo-small-01.jpg" alt="Photo Small 1" /> </div>
                        <div class="photo-caption">Photo caption goes here</div>
                    </div>
                    <div class="photo-container align-right" style="width:202px;">
                        <div class="photo-content"> <img src="../../Content/images/photo-small-02.jpg" alt="Photo Small 2" /> </div>
                        <div class="photo-caption">Photo caption goes here</div>
                    </div>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="data-table">
                        <caption>
                        &lt;caption&gt; Table Caption
                        </caption>
                        <tr>
                            <th scope="col">&lt;th&gt; Heading </th>
                            <th scope="col">&lt;th&gt; Heading</th>
                            <th scope="col">&lt;th&gt; Heading</th>
                            <th scope="col">&lt;th&gt; Heading</th>
                        </tr>
                        <tr>
                            <th scope="row">&lt;th&gt; Heading</th>
                            <td>content</td>
                            <td>content</td>
                            <td>content</td>
                        </tr>
                        <tr class="row-alternating">
                            <th scope="row">&lt;th&gt; Heading</th>
                            <td>content</td>
                            <td>content</td>
                            <td>content</td>
                        </tr>
                        <tr>
                            <th scope="row">&lt;th&gt; Heading</th>
                            <td>content</td>
                            <td>content</td>
                            <td>content</td>
                        </tr>
                        <tr class="row-alternating">
                            <th scope="row">&lt;th&gt; Heading</th>
                            <td>content</td>
                            <td>content</td>
                            <td>content</td>
                        </tr>
                    </table>
                    <div class="three-column-container">
                        <div class="three-column-left">
                            <h3>&lt;h3&gt; Header</h3>
                            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>
                        </div>
                        <div class="three-column-middle">
                            <h3>&lt;h3&gt; Header</h3>
                            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>
                        </div>
                        <div class="three-column-right">
                            <h3>&lt;h3&gt; Header</h3>
                            <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat.</p>
                        </div>
                        <div class="clear"></div>
                    </div>
                    <fieldset>
                    <legend>&lt;legend&gt; Legend</legend>
                    <label for="name">&lt;label&gt; Label </label>
                    <input class="input-box" name="name" id="name" type="text" size="50" />
                    <label for="email">&lt;label&gt; Label </label>
                    <input class="input-box" name="email" id="email" type="text" size="50" />
                    <label for="notesfield">&lt;label&gt; Label </label>
                    <textarea class="input-box" name="notesfield" cols="50" rows="4" id="notesfield"></textarea>
                    <label for="favmag1">&lt;label&gt; Label </label>
                    <select id="favmag1" name="favmag1" >
                        <option value="0" selected="selected">- - Select your favorite magazine - - </option>
                        <optgroup label="General Computer Magazines">
                        <option value="1">Computer A Magazine</option>
                        <option value="2">Computer B Magazine</option>
                        <option value="3">Computer C Magazinee</option>
                        </optgroup>
                        <optgroup label="Software Magazines">
                        <option value="5">Software A Magazine</option>
                        <option value="6">Software B Magazine</option>
                        <option value="7">Software C Magazine</option>
                        </optgroup>
                        <optgroup label="Hardware Magazine">
                        <option value="8">Hardware A Magazine</option>
                        <option value="9">Hardware B Magazinek</option>
                        <option value="10">Hardware C Magazine</option>
                        </optgroup>
                    </select>
                    <fieldset>
                    <legend>Lorem ipsum dolar</legend>
                    <label class="no-margin" for="radio1">
                    <input class="inline" type="radio" name="radio" id="radio1" title="&lt;label&gt; Label" checked="checked"  />
                    &lt;label&gt; Label </label>
                    <label class="no-margin" for="radio2">
                    <input class="inline" type="radio" name="radio" id="radio2" title="&lt;label&gt; Label"  />
                    &lt;label&gt; Label </label>
                    <label class="no-margin" for="radio3">
                    <input class="inline" type="radio" name="radio" id="radio3" title="&lt;label&gt; Label"  />
                    &lt;label&gt; Label </label>
                    </fieldset>
                    <div class="checkbox">
                        <label class="no-margin" for="check1">
                        <input class="inline" title="Subscribe" type="checkbox" name="check1" id="check1" value=""  />
                        &lt;label&gt; Label </label>
                    </div>
                    <input class="button button-big" name="Submit" type="button" value="Submit"  />
                    <input class="button button-big" name="Submit2" type="reset" value="Reset" />
                    </fieldset>
</asp:Content>
