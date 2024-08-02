<template>
  <v-dialog v-model="open" max-width="400px">
    <v-card>
      <v-card-title class="card-title">
        <div id="title">{{ title }}</div>
        <v-btn class="close-btn" small @click="close">
          <v-icon>mdi-close</v-icon>
        </v-btn>
      </v-card-title>
      <v-card-text class="card-body pa-0">
        <v-form @submit.prevent="submitForm" ref="form" v-model="valid">
          <div class="form-body">
            <v-text-field
              label="Name"
              :rules="nameRules"
              v-model="nameValue"
              placeholder="Enter the name"
              required
            >
            </v-text-field>
            <v-row class="dob-gender">
              <v-col cols="6">
                <v-text-field
                  label="Date Of Birth"
                  :rules="dateOfBirthRules"
                  type="date"
                  placeholder="Enter Date of Birth"
                  v-model="dobValue"
                  :max="maxDate"
                  required
                >
                </v-text-field>
              </v-col>
              <v-col cols="6" class="pb-0 pr-0">
                <v-radio-group
                  class="mt-0"
                  label="Gender"
                  v-model="genderValue"
                  :rules="radioRules"
                >
                  <v-radio label="Male" value="Male"> </v-radio>
                  <v-radio label="Female" value="Female"></v-radio>
                </v-radio-group>
              </v-col>
            </v-row>

            <v-textarea
              class="pt-0"
              label="Bio"
              rows="3"
              required
              placeholder="Enter the description"
              v-model="bioValue"
              :rules="bioRules"
            ></v-textarea>
          </div>
          <div class="card-action">
            <v-btn type="submit" class="submit-btn">Submit</v-btn>
          </div>
        </v-form>
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  emits: ["close-model", "update-actor"],
  props: ["title", "isOpen"],
  watch: {
    isOpen(newval) {
      this.open = newval;
    },
    open(newval) {
      if (!newval) {
        this.close();
      }
    },
  },
  data() {
    return {
      valid: false,
      open: this.isOpen,
      nameValue: "",
      dobValue: "",
      genderValue: "",
      bioValue: "",
      maxDate: new Date().toISOString().split("T")[0],
      nameRules: [
        (value) => {
          if (value) return true;
          return "You must enter name.";
        },
      ],
      dateOfBirthRules: [
        (v) => !!v || "You must enter the date of birth.",
        (v) => new Date(v) <= new Date() || "Enter a valid date.",
      ],
      bioRules: [
        (v) => !!v || "You must enter the bio.",
        (v) =>
          (v && v.length >= 10) || "Plot must be at least 10 characters long.",
      ],
      radioRules: [(v) => !!v || "You must select an gender."],
    };
  },
  methods: {
    close() {
      this.open = false;
      this.$emit("close-model");
      this.$refs.form.reset();
    },
    submitForm() {
      if (!this.$refs.form.validate()) {
        return;
      }
      const entityInfo = {
        name: this.nameValue,
        bio: this.bioValue,
        dob: this.dobValue,
        gender: this.genderValue,
      };
      this.$emit(
        "update-actor",
        entityInfo,
        this.title === "ADD ACTOR" ? 1 : 2
      );
      this.close();
    },
  },
};
</script>

<style scoped>
div#title {
  color: #ffffff;
}
.card-title {
  display: flex;
  justify-content: space-between;
  align-items: center;
  background: #2c3e50;
}
.card-title .close-btn {
  background-color: #dc3545;
}
.card-body {
  background-color: #f5f5f5;
  color: #333333;
}
.card-action {
  padding: 10px;
  display: flex;
  justify-content: end;
  background-color: #ececec;
}
.card-action .submit-btn {
  background-color: #6cd986;
}
.dob-gender {
  display: flex;
  justify-content: space-between;
  align-items: start;
}
.form-body {
  padding: 15px;
}
</style>
