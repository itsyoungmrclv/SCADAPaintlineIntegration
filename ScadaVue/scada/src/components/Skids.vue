<template>
  <v-flex>
    <v-toolbar flat>
      <v-toolbar-title class="text-h5">Paintline Process Skids</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-spacer></v-spacer>
      <v-spacer></v-spacer>
      <v-spacer></v-spacer>
      <v-spacer></v-spacer>
      <v-spacer></v-spacer>
      <v-spacer></v-spacer>
      <v-spacer></v-spacer>
      <template v-if="searchby === 'Date'">
        <v-menu :close-on-content-click="true" transition="scale-transition" offset-y max-width="290px">
          <template v-slot:activator="{ on }">
            <v-text-field
              v-model="search"
              class="text-xs-center"
              label="Search by Date"
              readonly v-on="on"
              append-icon="event"
              single-line
              hide-details
              clearable
            >
            </v-text-field>
          </template>
          <v-date-picker
            v-model="search"
            :max="(new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000)).toISOString().substr(0, 10)"
            :min="(new Date(Date.now() - (new Date()).getTimezoneOffset() * 60000 * 24 * 120)).toISOString().substr(0, 10)"
            locale="en"></v-date-picker>
        </v-menu>
      </template>
      <template v-if="searchby === 'LabelID'">
        <v-text-field
          v-model="search"
          class="text-xs-center"
          append-icon="pin"
          label="Search by LabelID"
          type="number"
          :maxlength="8"
          single-line
          clearable
          ></v-text-field>
      </template>
      <v-spacer></v-spacer>
      <v-btn-toggle v-model="searchby">
        <p class="text-xs-center ma-3">Search by:</p>
        <v-btn value="LabelID" @click="clearSearch">
          <v-icon start class="ma-2">pin</v-icon>LabelID
        </v-btn>
        <v-btn value="Date" @click="clearSearch">
          <v-icon start class="ma-2">event</v-icon>Date
        </v-btn>
      </v-btn-toggle>
      <v-spacer></v-spacer>
      <v-btn color="primary" @click="getFilteredSkids"><v-icon start class="ma-2">search</v-icon>Search</v-btn>
      <v-spacer></v-spacer>
    </v-toolbar>
    <v-data-table
      :headers="SkidsHeaders"
      :items="Skids"
      item-key="labelID"
      :loading="loading"
      :items-per-page=15
      :expanded.sync="expanded"
      show-expand
      single-expand
      sort-by="dateAndTimeIN"
      class="elevation-2"
    >
      <template v-slot:loading>
        <v-skeleton-loader type="table-row@15"></v-skeleton-loader>
      </template>
      <template v-slot:expanded-item="{ headers, item }">
      <td :colspan="headers.length">
          <expanded-element :itemExpandedLabelID = item.labelID></expanded-element>
        </td>
      </template>
    </v-data-table>
  </v-flex>
</template>
<script>
import axios from 'axios'
import ExpandedElement from './ExpandedElement.vue';

export default {
  data() {
    return {
      SkidsHeaders: [
        { text: 'Date of process', value: 'dateAndTimeIN' },
        { text: 'LabelID', value: 'labelID' },
        { text: 'Type', value: 'typeLab' },
        { text: 'Color', value: 'colorLab', sortable: false },
        { text: 'Primer', value: 'primerLab', sortable: false },
        { text: 'Clear', value: 'clearLab', sortable: false },
        { text: 'QTY1', value: 'qtY1', sortable: false },
        { text: 'QTY2', value: 'qtY2', sortable: false },
        { text: 'CO2', value: 'cO2', sortable: false },
        { text: 'Flaming', value: 'flaming', sortable: false },
        { text: 'Basecoat', value: 'basecoat', sortable: false },
        { text: 'Status', value: 'position', sortable: false }
      ],
      Skids: [],
      searchby: 'LabelID',
      search: '',
      APIerror:'',
      loading: false,
      errorFlag: false,
      expanded: [],
      itemExpandedLabelID: '',
    }
  },
  methods: {
    getLastSkids() {
      this.loading = true;
      axios.get('Skidprotocols/GetLastSkids')
        .then(response => {
          this.Skids = response.data;
        })
        .catch(error => {
          console.error(error);
        })
        .finally(() => {
          this.loading = false;
        });
    },
    getFilteredSkids(){
      this.loading = true;
      let urlComplement;
      switch(this.searchby){
        case 'Date' : urlComplement = 'GetSkidsByDate/'; break;
        case 'LabelID' : urlComplement = 'GetSkidByLabelID/'; break;
      }
      const url = 'Skidprotocols/' + urlComplement + this.search;
      axios.get(url)
        .then(response => {
          switch(this.searchby){
            case 'Date' :
              this.Skids = response.data;
              break;
            case 'LabelID' :
              this.Skids = [response.data];
              break;
        }
          console.log(this.Skids);
        })
        .catch(error => {
          this.errorFlag = true;
          this.APIerror = error.response.statusText;
        })
        .finally(() => {
          this.loading = false;
        });
    },
    clearSearch(){
      this.search = '';
    },
  },
  components:{
    'expanded-element': ExpandedElement
  },
  created() {
    this.getLastSkids();
  }
}
</script>
